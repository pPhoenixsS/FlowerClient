using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerClient.Model;
using FlowerClient.PresenterProducts;
using FlowerClient.view;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace FlowerClient.View
{
    public partial class AdminView : Form, IAdminView
    {
        private readonly IAdminPresenter presenter;

        private List<string> photoPaths;
        private int currentPhotoIndex;

        public AdminView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;

            presenter = new AdminPresenter(this);

            photoPaths = new List<string>();
            currentPhotoIndex = -1; // Изначально нет выбранной фотографии

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
                OnePanel.Size = new Size(206, 368);
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

                // Создать кнопку "удалить"
                Button delete = new Button();
                delete.Text = "Удалить";
                delete.AutoSize = true;
                delete.BackColor = Color.LightPink;
                delete.Font = new Font("Monotype Corsiva", 14);

                // Создать обработчик события для кнопки "удалить"
                delete.Click += async (sender, e) =>
                {
                    await presenter.DeleteProduct(product.Id); // вызов запроса на удаление

                    if (presenter.ResultAsync == "ok")
                    {
                        MessageBox.Show("Продукт успешно удален");
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

        private void AddPicture_Click(object sender, EventArgs e) // добавление фото
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    photoPaths.Add(selectedFilePath);
                    currentPhotoIndex = photoPaths.Count - 1;
                    DisplayCurrentPhoto();
                }
            }
        }

        private void DeletePicture_Click(object sender, EventArgs e) // удаление фото
        {
            if (currentPhotoIndex >= 0 && currentPhotoIndex < photoPaths.Count)
            {
                photoPaths.RemoveAt(currentPhotoIndex);

                if (photoPaths.Count == 0)
                {
                    pictureBox.Image = null;
                    currentPhotoIndex = -1;
                }
                else
                {
                    currentPhotoIndex = currentPhotoIndex % photoPaths.Count;
                    DisplayCurrentPhoto();
                }
            }
        }

        public void DisplayCurrentPhoto()
        {
            if (currentPhotoIndex >= 0 && currentPhotoIndex < photoPaths.Count)
            {
                string selectedFilePath = photoPaths[currentPhotoIndex];
                if (File.Exists(selectedFilePath))
                {
                    pictureBox.Image = new Bitmap(selectedFilePath);
                }
                else
                {
                    MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (photoPaths.Count > 0)
            {
                currentPhotoIndex = (currentPhotoIndex + 1) % photoPaths.Count;
                DisplayCurrentPhoto();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (photoPaths.Count > 0)
            {
                currentPhotoIndex = (currentPhotoIndex - 1 + photoPaths.Count) % photoPaths.Count;
                DisplayCurrentPhoto();
            }
        }

        private async void AddProduct_Click(object sender, EventArgs e) // добавление продукта
        {
            // Проверка, что все поля не пустые
            if (!string.IsNullOrEmpty(NameProduct.Text) &&
                !string.IsNullOrEmpty(Kind.Text) &&
                !string.IsNullOrEmpty(Description.Text) &&
                !string.IsNullOrEmpty(Price.Text) &&
                !string.IsNullOrEmpty(Count.Text) &&
                photoPaths != null)
            {
                // Проверка, что Цена является числом и Количество является целым числом
                if (double.TryParse(Price.Text, out double result1) && int.TryParse(Count.Text, out int result2))
                {
                    // Добавление продукта
                    await presenter.AddProduct(NameProduct.Text, Kind.Text, Description.Text, result1, result2, photoPaths);

                    if (presenter.ResultAsync == "ok")
                    {
                        MessageBox.Show("Пост успешно опубликован");
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show(presenter.ResultAsync);
                    }

                    // Очистка полей
                    NameProduct.Clear();
                    Kind.Clear();
                    Description.Clear();
                    Price.Clear();
                    Count.Clear();
                    pictureBox.Image = null;
                    photoPaths = new List<string>();
                    currentPhotoIndex = -1;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните поля Цена и Количество корректными числовыми значениями.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля для добавления товара.");
            }
        }
    }
}
