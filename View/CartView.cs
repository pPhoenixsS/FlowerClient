using FlowerClient.Model;
using FlowerClient.PresenterProducts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using Timer = System.Windows.Forms.Timer;

namespace FlowerClient.View
{
    public partial class CartView : Form, ICartView
    {
        private readonly ICartPresenter presenter;

        public CartView()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;

            presenter = new CartPresenter(this);

            LoadProducts();
        }

        private void GoMain_Click(object sender, EventArgs e)
        {
            MainProductsView main = new MainProductsView(); // создаем новую форму
            main.Show(); // показываем форму
            this.Hide(); // скрываем текущую форму
            main.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }

        public async void LoadProducts()
        {
            List<CartItem> productsBuy = await presenter.AllProductsInCart();

            if (productsBuy == null || productsBuy.Count == 0)
            {
                flowLayoutPanelProduct.Controls.Clear();
                Sum.Text = "0";
                BonusesCount();
                return;
            }

            DisplayProducts(productsBuy);
            SumPrice(productsBuy);
            BonusesCount();
        }

        public async void DisplayProducts(List<CartItem> productsBuy)
        {
            flowLayoutPanelProduct.Controls.Clear(); // Очистить существующие элементы управления
            flowLayoutPanelProduct.BackColor = Color.Transparent; // Установка прозрачного цвета фона

            flowLayoutPanelProduct.WrapContents = true; // Переносить элементы на новую строку при достижении края контейнера

            foreach (var productBuy in productsBuy)
            {
                Product product = await presenter.OneProduct(productBuy.productId);

                // Создать панель для каждого продукта
                FlowLayoutPanel OnePanel = new FlowLayoutPanel();
                OnePanel.FlowDirection = FlowDirection.TopDown;
                OnePanel.Size = new Size(230, 460);
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
                countBuy.Text = productBuy.count.ToString();
                countBuy.ReadOnly = true;
                countBuy.Font = new Font("Monotype Corsiva", 14);
                countBuy.AutoSize = true;
                panelBuy.Controls.Add(countBuy);

                OnePanel.Controls.Add(panelBuy);

                // Создать кнопку "изменить"
                Button btnUpdate = new Button();
                btnUpdate.Text = "Изменить количество";
                btnUpdate.AutoSize = true;
                btnUpdate.Font = new Font("Monotype Corsiva", 14);
                btnUpdate.BackColor = Color.LightPink;

                bool IsUpdated = false; // до нажатия кнопки изменения количество не изменено

                // Создать обработчик события для кнопки "Изменить количество"
                btnUpdate.Click += async (sender, e) =>
                {
                    // Если количество еще не изменено пользователем, то изменяем
                    if (IsUpdated != true)
                    {
                        btnUpdate.Text = "Сохранить";

                        // открываем для изменения текстбокс
                        countBuy.ReadOnly = false;

                        IsUpdated = true;
                    }
                    // Иначе сохраняем
                    else
                    {
                        if (int.TryParse(countBuy.Text, out int value))
                        {
                            if (value > product.Count)
                            {
                                countBuy.Text = product.Count.ToString();
                                MessageBox.Show($"Значение не должно превышать {product.Count}. Установлено максимальное значение.");
                            }

                            await presenter.AddProductToCart(product.Id, int.Parse(countBuy.Text)); // добавляем товар в корзину с новым количеством 

                            if (presenter.ResultAsync == "ok")
                            {
                                MessageBox.Show("Количество товара изменено");
                                LoadProducts();
                            }
                            else
                            {
                                MessageBox.Show(presenter.ResultAsync);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введено некорректное целое количество товара.");

                            countBuy.Text = productBuy.count.ToString();
                        }

                        IsUpdated = false;

                        // закрываем для изменения текстбокс
                        countBuy.ReadOnly = true;

                        btnUpdate.Text = "Изменить";
                    }
                };

                // Добавить кнопку изменения к панели
                OnePanel.Controls.Add(btnUpdate);

                // Создать кнопку "удалить из корзины"
                Button delete = new Button();
                delete.Text = "Удалить из корзины";
                delete.AutoSize = true;
                delete.BackColor = Color.LightPink;
                delete.Font = new Font("Monotype Corsiva", 14);

                // Создать обработчик события для кнопки "удалить из корзины"
                delete.Click += async (sender, e) =>
                {
                    await presenter.AddProductToCart(product.Id, 0); // добавляем товар в корзину с количеством 0

                    if (presenter.ResultAsync == "ok")
                    {
                        MessageBox.Show("Продукт удален из корзины");
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show(presenter.ResultAsync);
                    }
                };

                OnePanel.Controls.Add(delete);

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
                        // Устанавливаем положение формы рядом со значком (справа от него)
                        Point iconLocation = iconPictureBox.PointToScreen(Point.Empty);
                        tooltipForm.Location = new Point(iconLocation.X + iconPictureBox.Width, iconLocation.Y);
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

        public async void BonusesCount() // указываем количество имеющихся бонусов
        {
            Bonus bonus = await presenter.BonusesForBuy();

            if (bonus != null)
            {
                Bonuses.Text = bonus.Bonuses.ToString();
            }
            else
            {
                Bonuses.Text = "0";
            }
        }

        private async void Buy_Click(object sender, EventArgs e)
        {
            if (Sum.Text != null && Sum.Text != "0")
            {
                Bonus bonus = await presenter.BonusesForBuy();

                if (!string.IsNullOrWhiteSpace(UseBonuses.Text) && int.Parse(UseBonuses.Text) >= 0)
                {
                    if (int.TryParse(UseBonuses.Text, out int value))
                    {
                        if (value > bonus.Bonuses)
                        {
                            UseBonuses.Text = bonus.Bonuses.ToString();
                            MessageBox.Show($"Значение не должно превышать {bonus.Bonuses}. Установлено максимальное значение.");
                        }

                        await presenter.BuyProductsWitnBonuses(int.Parse(UseBonuses.Text));
                        MessageBox.Show($"Вы купили все товары, использовав {UseBonuses.Text} бонусов. Спасибо за покупку! Ждем Вас снова!");
                        LoadProducts();
                        Bonuses.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное целое значение бонусов для использования");
                    }
                }
                else
                {
                    MessageBox.Show("Введите целое значение бонусов для использования");
                }
            }
            else
            {
                MessageBox.Show("Чтобы что-то купить, нужно сначала положить в корзину......");
            }
        }

        public async void SumPrice(List<CartItem> productsBuy)
        {
            double Summa = 0;

            foreach (var productBuy in productsBuy)
            {
                Product product = await presenter.OneProduct(productBuy.productId);

                Summa += product.Price * productBuy.count;
            }

            Sum.Text = Summa.ToString();
        }
    }
}