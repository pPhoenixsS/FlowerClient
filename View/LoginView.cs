using FlowerClient.model;
using FlowerClient.presenter;
using FlowerClient.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Header = FlowerClient.model.Header;

namespace FlowerClient.view
{
    public partial class LoginView : Form, ILoginView
    {
        private readonly ILoginPresenter presenter;

        public LoginView()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            presenter = new LoginPresenter(this);

            // Устанавливаем свойство UseSystemPasswordChar в true (для скрытия пароля)
            textBoxPassword.UseSystemPasswordChar = true;

            // Добавляем обработчик для всех текстбоксов на форме (нужно для запрета копирования пароля)
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
                    textBox.ContextMenu = new ContextMenu(); // Убираем контекстное меню
                }
            }
        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            await presenter.Login(textBoxEmail.Text, textBoxPassword.Text);
            var _headers = Header.headers;
            if (presenter.ResultAsync == "ok")
            {
                MessageBox.Show("Вход успешно выполнен");
                HomePageView homepage = new HomePageView(); // создаем новую форму
                homepage.Show(); // показываем форму
                this.Hide(); // скрываем текущую форму
                homepage.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
            }
            else
            {
                MessageBox.Show(presenter.ResultAsync);
                textBoxEmail.Clear();
                textBoxPassword.Clear();
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            RegisterView register = new RegisterView();
            register.Show();
            this.Hide(); // скрываем текущую форму
            register.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) // Обработчик события нажатия клавиш копирования (чтобы нельзя было скопировать пароль и вставить)
        {
            // Запрещаем Ctrl+C, Ctrl+X, Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
