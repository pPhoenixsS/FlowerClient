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
    public partial class ProductTooltipForm : Form
    {
        private PictureBox pictureBox;
        private Timer timer;
        private List<string> imagePaths;
        private int currentIndex;

        public ProductTooltipForm(string productName, string productKind, string productDescription, List<string> images)
        {
            // Инициализация формы
            Text = productName;
            Size = new Size(300, 400); // Увеличил высоту для умещения информации
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;

            // Инициализация PictureBox для отображения картинок
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Top;
            Controls.Add(pictureBox);

            // Инициализация списка путей к изображениям
            imagePaths = images;

            // Установка информации о продукте под картинкой
            Label nameLabel = new Label();
            nameLabel.Text = "Название: " + productName;
            nameLabel.Dock = DockStyle.Top;
            nameLabel.Font = new Font("Corsiva", 14);
            Controls.Add(nameLabel);

            Label typeLabel = new Label();
            typeLabel.Text = "Сорт: " + productKind;
            typeLabel.Dock = DockStyle.Top;
            typeLabel.Font = new Font("Corsiva", 14);
            Controls.Add(typeLabel);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = "Описание: " + productDescription;
            descriptionLabel.Dock = DockStyle.Top;
            descriptionLabel.Font = new Font("Corsiva", 14);
            Controls.Add(descriptionLabel);

            // Установка размера формы, чтобы вместить изображение и информацию о продукте
            pictureBox.Image = Image.FromFile(images[0]);
            Height += pictureBox.Height; // Увеличиваем высоту формы на высоту изображения
            currentIndex = 1; // Начинаем с первого изображения после основного

            // Инициализация таймера для автоматического переключения изображений
            timer = new Timer();
            timer.Interval = 3000; // 3 секунды
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void ShowNextImage()
        {
            pictureBox.Image = Image.FromFile(imagePaths[currentIndex]);
            currentIndex = (currentIndex + 1) % imagePaths.Count; // Переход к следующему изображению или начало сначала
        }
    }
}
