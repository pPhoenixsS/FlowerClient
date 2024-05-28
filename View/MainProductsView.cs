using FlowerClient.Model;
using FlowerClient.presenter;
using FlowerClient.PresenterProducts;
using FlowerClient.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerClient.View
{
    public partial class MainProductsView : Form, IMainProductsView
    {
        private readonly IMainProductsPresenter presenter;

        public MainProductsView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            presenter = new MainProductsPresenter(this);

            Admin.Visible = presenter.GetRole() == "Admin"; // показываем кнопку админа, если роль админ

            LoadProducts();
        }

        private void ExitProfile_Click(object sender, EventArgs e)
        {
            LoginView login = new LoginView(); // создаем новую форму
            login.Show(); // показываем форму
            this.Hide(); // скрываем текущую форму
            login.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            CartView cart = new CartView(); // создаем новую форму
            cart.Show(); // показываем форму
            this.Hide(); // скрываем текущую форму
            cart.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            AdminView admin = new AdminView(); // создаем новую форму
            admin.Show(); // показываем форму
            this.Hide(); // скрываем текущую форму
            admin.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }

        public async void LoadProducts()
        {
            List<Product> products = await presenter.AllProducts();

            if (products == null)
                return;

            DisplayProducts(products);
        }

        public void DisplayProducts(List<Product> products)
        {
            flowLayoutPanelProduct.Controls.Clear(); // Очистить существующие элементы управления

            flowLayoutPanelProduct.WrapContents = false; // перенос при достижении кря контейнера

            foreach (var product in products)
            {
                // Создать панель для каждого продукта
                FlowLayoutPanel OnePanel = new FlowLayoutPanel();
                OnePanel.FlowDirection = FlowDirection.TopDown;
                OnePanel.AutoSize = true;
                OnePanel.BackColor = Color.Blue;
                OnePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Создать метку для отображения картинки (одной) продукта
                PictureBox imageOne = new PictureBox();
                imageOne.Image = Image.FromFile(product.Images[0]);
                imageOne.Width = 50; // Фиксированная ширина
                imageOne.Height = 50; // Фиксированная высота
                OnePanel.Controls.Add(imageOne);

                // Создать метку для отображения названия продукта
                Label label = new Label();
                label.Text = product.Name;
                label.Font = new Font("Corsiva", 14);
                OnePanel.Controls.Add(label);

                // Создать метку для отображения цены продукта
                Label price = new Label();
                price.Text = product.Price.ToString() + " руб";
                price.Font = new Font("Corsiva", 14);
                OnePanel.Controls.Add(price);

                // Создать метку для отображения кол-ва для заказа продукта
                TextBox count = new TextBox();
                count.ReadOnly = false;
                count.BorderStyle = BorderStyle.None; // Убрать границы 
                count.Width = 10; // Фиксированная ширина
                count.Font = new Font("Corsiva", 14);
                OnePanel.Controls.Add(price);

                // Создать кнопку "добавить в корзину"
                Button toCart = new Button();
                toCart.Text = "В корзину";
                toCart.AutoSize = true;
                toCart.Font = new Font("Corsiva", 14);

                // Обработчик события Click для кнопки "Добавить в корзину"
                toCart.Click += (sender, e) =>
                {
                    // Создание и отображение формы корзины
                    CartView cartForm = new CartView(); // создаем новую форму
                    cartForm.Show(); // показываем форму
                    this.Hide(); // скрываем текущую форму
                    cartForm.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
                };

                OnePanel.Controls.Add(toCart);

                // Объявление переменной для хранения формы подсказки
                ProductTooltipForm tooltipForm = null;

                // Обработчик события MouseEnter для панели
                OnePanel.MouseEnter += (sender, e) =>
                {
                    // Проверяем, что форма подсказки еще не отображается
                    if (tooltipForm == null)
                    {
                        // Создаем и показываем форму подсказки
                        tooltipForm = new ProductTooltipForm(product.Name, product.Kind, product.Description, product.Images);
                        tooltipForm.Show();
                    }
                };

                // Обработчик события MouseLeave для панели
                OnePanel.MouseLeave += (sender, e) =>
                {
                    // Проверяем, что форма подсказки отображается
                    if (tooltipForm != null)
                    {
                        // Закрываем и освобождаем ресурсы формы подсказки
                        tooltipForm.Close();
                        tooltipForm.Dispose();
                        tooltipForm = null;
                    }
                };

                flowLayoutPanelProduct.Controls.Add(OnePanel);
            }

            flowLayoutPanelProduct.PerformLayout(); // Обновить макет для обновления полос прокрутки
        }
    }
}