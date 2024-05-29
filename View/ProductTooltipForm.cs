using FlowerClient.Model;
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
    public partial class ProductTooltipForm : Form
    {
        private PictureBox pictureBox;
        private Timer timer;
        private List<byte[]> imageBytes;
        private int currentIndex;

        public ProductTooltipForm(string productName, string productKind, string productDescription, int productCount, double productPrice, List<byte[]> images)
        {
            // Создать панель для каждого продукта
            FlowLayoutPanel Panelka = new FlowLayoutPanel();
            Panelka.FlowDirection = FlowDirection.TopDown;
            Panelka.BackColor = Color.LightPink;
            Panelka.WrapContents = false;
            Panelka.Size = new Size(300, 300);
            Panelka.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Инициализация PictureBox для отображения картинок
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(200, 200); // Устанавливаем размер PictureBox
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения
            Panelka.Controls.Add(pictureBox);

            // Инициализация списка массивов байтов изображений
            imageBytes = images;

            // Установка информации о продукте под картинкой
            Label nameLabel = new Label();
            nameLabel.Text = productName;
            nameLabel.Font = new Font("Monotype Corsiva", 14, FontStyle.Bold);
            nameLabel.AutoSize = true;
            nameLabel.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
            Panelka.Controls.Add(nameLabel);

            Label typeLabel = new Label();
            typeLabel.Text = "Сорт: " + productKind;
            typeLabel.Font = new Font("Monotype Corsiva", 14);
            typeLabel.AutoSize = true;
            typeLabel.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
            Panelka.Controls.Add(typeLabel);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = "Описание: " + productDescription;
            descriptionLabel.Font = new Font("Monotype Corsiva", 14);
            descriptionLabel.AutoSize = true;
            descriptionLabel.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
            Panelka.Controls.Add(descriptionLabel);

            Label countLabel = new Label();
            countLabel.Text = "В наличии: " + productCount + " шт.";
            countLabel.Font = new Font("Monotype Corsiva", 14);
            countLabel.AutoSize = true;
            countLabel.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
            Panelka.Controls.Add(countLabel);

            Label priceLabel = new Label();
            priceLabel.Text = "Цена: " + productPrice + " руб.";
            priceLabel.Font = new Font("Monotype Corsiva", 14);
            priceLabel.AutoSize = true;
            priceLabel.Margin = new Padding(0, 0, 0, 10); // Добавляем отступ снизу
            Panelka.Controls.Add(priceLabel);

            // Установка размера формы, чтобы вместить изображение и информацию о продукте
            if (images != null && images.Count > 0)
            {
                using (var ms = new MemoryStream(images[0]))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
                Height += pictureBox.Height; // Увеличиваем высоту формы на высоту изображения
            }

            currentIndex = 1; // Начинаем с первого изображения после основного

            // Инициализация таймера для автоматического переключения изображений
            timer = new Timer();
            timer.Interval = 3000; // 3 секунды
            timer.Tick += Timer_Tick;
            timer.Start();

            // Добавление панели на форму
            this.Controls.Add(Panelka);

            // Настройка формы
            this.Text = "Подробная информация";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(300,400);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void ShowNextImage()
        {
            if (imageBytes != null && imageBytes.Count > 0)
            {
                using (var ms = new MemoryStream(imageBytes[currentIndex]))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
                currentIndex = (currentIndex + 1) % imageBytes.Count; // Переход к следующему изображению или с начала
            }
        }
    }
}