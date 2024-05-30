using FlowerClient.model;
using FlowerClient.Model;
using FlowerClient.presenter;
using FlowerClient.PresenterProducts;
using FlowerClient.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace FlowerClient.View
{
    public partial class MainProductsView : Form, IMainProductsView
    {
        private readonly IMainProductsPresenter presenter;
        LoginModel model;

        public MainProductsView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;

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
            flowLayoutPanelProduct.BackColor = Color.Transparent; // Установка прозрачного цвета фона

            flowLayoutPanelProduct.WrapContents = true; // Переносить элементы на новую строку при достижении края контейнера

            foreach (var product in products)
            {
                // Создать панель для каждого продукта
                FlowLayoutPanel OnePanel = new FlowLayoutPanel();
                OnePanel.FlowDirection = FlowDirection.TopDown;
                OnePanel.Size = new Size(206, 410);
                OnePanel.BackColor = Color.Pink;
                OnePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Создание значка
                PictureBox iconPictureBox = new PictureBox();
                iconPictureBox.Image = Properties.Resources.details1;
                iconPictureBox.Size = new Size(30, 30); // Устанавливаем размер PictureBox
                iconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения
                iconPictureBox.Cursor = Cursors.Hand; // Устанавливаем курсор руки при наведении

                // Добавляем значок на панель
                OnePanel.Controls.Add(iconPictureBox);

                // Создать метку для отображения картинки (одной) продукта
                PictureBox imageOne = new PictureBox();

                // Преобразовать массив байтов в изображение
                if (product.ImagesByte != null && product.ImagesByte.Count > 0)
                {
                    using (var ms = new MemoryStream(product.ImagesByte[0]))
                    {
                        imageOne.Image = Image.FromStream(ms);
                    }
                }
                imageOne.Size = new Size(200, 200); // Устанавливаем размер PictureBox
                imageOne.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения
                OnePanel.Controls.Add(imageOne);

                // Создать метку для отображения названия продукта
                Label label = new Label();
                label.Text = product.Name;
                label.Font = new Font("Monotype Corsiva", 14, FontStyle.Bold);
                label.AutoSize = true;
                label.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
                OnePanel.Controls.Add(label);

                // Создать метку для отображения цены продукта
                Label price = new Label();
                price.Text = product.Price.ToString() + " руб";
                price.Font = new Font("Monotype Corsiva", 14);
                price.AutoSize = true;
                price.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
                OnePanel.Controls.Add(price);

                // Создать панель для текстбокса
                FlowLayoutPanel panelBuy = new FlowLayoutPanel();
                panelBuy.AutoSize = true;

                // Создать метку для отображения количества для покупки
                Label countBuyName = new Label();
                countBuyName.Text = "Кол-во:";
                countBuyName.Font = new Font("Monotype Corsiva", 14);
                countBuyName.AutoSize = true;
                panelBuy.Controls.Add(countBuyName);

                // Создать метку для отображения количества покупаемого продукта
                TextBox countBuy = new TextBox();
                countBuy.ReadOnly = false;
                countBuy.Font = new Font("Monotype Corsiva", 14);
                countBuy.AutoSize = true;
                panelBuy.Controls.Add(countBuy);

                OnePanel.Controls.Add(panelBuy);

                // Создать кнопку "В корзину"
                Button putToCart = new Button();
                putToCart.Text = "В корзину";
                putToCart.AutoSize = true;
                putToCart.BackColor = Color.LightPink;
                putToCart.Font = new Font("Monotype Corsiva", 14);

                // Создать обработчик события для кнопки "В корзину"
                putToCart.Click += (sender, e) =>
                {
                    int countBuyProduct = int.Parse(countBuy.Text);
                    ShoppingCart.AddProductToCart(model.Email, product, countBuyProduct); // добавляем товар в корзину
                };

                OnePanel.Controls.Add(putToCart);

                // Объявление переменной для хранения формы подсказки
                ProductTooltipForm tooltipForm = null;
                // Таймер для периодической проверки положения курсора
                Timer tooltipTimer = new Timer { Interval = 100 }; // Проверяем каждые 100 мс

                // Обработчик события MouseEnter для значка
                iconPictureBox.MouseEnter += (sender, e) =>
                {
                    // Проверяем, что форма подсказки еще не отображается
                    if (tooltipForm == null)
                    {
                        // Создаем и показываем форму подсказки
                        tooltipForm = new ProductTooltipForm(product.Name, product.Kind, product.Description, product.Count, product.Price, product.ImagesByte);
                        tooltipForm.StartPosition = FormStartPosition.Manual;
                        // Устанавливаем положение формы рядом со значком (слева от него)
                        Point iconLocation = iconPictureBox.PointToScreen(Point.Empty);
                        tooltipForm.Location = new Point(iconLocation.X - tooltipForm.Width, iconLocation.Y);
                        tooltipForm.Show();

                        // Запускаем таймер
                        tooltipTimer.Tick += TooltipTimer_Tick;
                        tooltipTimer.Start();
                    }
                };

                // Обработчик события MouseLeave для значка
                iconPictureBox.MouseLeave += (sender, e) =>
                {
                    CheckAndCloseTooltipForm();
                };

                // Метод для периодической проверки положения курсора
                void TooltipTimer_Tick(object sender, EventArgs e)
                {
                    CheckAndCloseTooltipForm();
                }

                // Метод для проверки местоположения курсора и закрытия формы подсказки
                void CheckAndCloseTooltipForm()
                {
                    if (tooltipForm != null &&
                        !tooltipForm.ClientRectangle.Contains(tooltipForm.PointToClient(Cursor.Position)) &&
                        !iconPictureBox.ClientRectangle.Contains(iconPictureBox.PointToClient(Cursor.Position)))
                    {
                        CloseTooltipForm();
                    }
                }

                // Метод для закрытия формы подсказки
                void CloseTooltipForm()
                {
                    if (tooltipForm != null)
                    {
                        tooltipTimer.Stop();
                        tooltipTimer.Tick -= TooltipTimer_Tick;

                        tooltipForm.Close();
                        tooltipForm.Dispose();
                        tooltipForm = null;
                    }
                }

                flowLayoutPanelProduct.Controls.Add(OnePanel);
            }

            flowLayoutPanelProduct.PerformLayout(); // Обновить макет для обновления полос прокрутки
        }
    }
}