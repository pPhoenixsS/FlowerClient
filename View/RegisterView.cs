using FlowerClient.model;
using FlowerClient.presenter;
using FlowerClient.view;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Header = FlowerClient.model.Header;

namespace FlowerClient
{
    public partial class RegisterView : Form, IRegisterView
    {
        private readonly IRegisterPresenter presenter;

        public RegisterView()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            presenter = new RegisterPresenter(this);

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

        private async void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (CheckingInput.IsValidEmail(textBoxEmail.Text) && CheckingInput.IsStrongPassword(textBoxPassword.Text))
            {
                await presenter.Register(textBoxEmail.Text, textBoxPassword.Text);
                var _headers = Header.headers;

                if (presenter.ResultAsync == "ok")
                {
                    MessageBox.Show("Аккаунт успешно зарегистрирован");
                    LoginView auth = new LoginView();
                    auth.Show(); // показываем форму
                    this.Hide(); // скрываем текущую форму
                    auth.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
                }
                else
                {
                    MessageBox.Show(presenter.ResultAsync);
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("Пароль должен иметь длину не менее 8 символов, содержать символы разного регистра, цифры и хотя бы один специальный символ. Email должен соответствовать формату email адреса.");
                textBoxEmail.Clear();
                textBoxPassword.Clear();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) // Обработчик события нажатия клавиш копирования (чтобы нельзя было скопировать пароль и вставить)
        {
            // Запрещаем Ctrl+C, Ctrl+X, Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginView auth = new LoginView();
            auth.Show(); // показываем форму
            this.Hide(); // скрываем текущую форму
            auth.FormClosed += (s, args) => this.Close(); // подписываемся на событие FormClosed новой формы, чтобы закрыть текущую форму
        }
    }
}
