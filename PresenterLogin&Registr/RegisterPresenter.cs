using FlowerClient.model;
using FlowerClient.view;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.presenter
{
    internal class RegisterPresenter : IRegisterPresenter
    {
        IRegisterView view;
        RegisterModel model;
        string result;

        public RegisterPresenter(IRegisterView view)
        {
            this.view = view;
            this.model = new RegisterModel();
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task Register(string email, string pass) // регистрация в системе
        {
            // Создание HTTP клиента для отправки запросов на сервер
            using HttpClient httpClient = new HttpClient();

            // Создание тела запроса в формате JSON
            var body = new
            {
                email = email,
                password = pass,
            };

            // Сериализация объекта 'body' в JSON-строку
            string jsonBody = JsonConvert.SerializeObject(body);
            // Создание объекта StringContent с JSON-строкой, кодировкой UTF-8 и MIME-типом "application/json"
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Отправка POST запроса на сервер
            var response = await httpClient.PostAsync("http://localhost:5000/register", content);

            // Проверка результата отправленного запроса
            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    result = "Неверный логин или пароль";
                    break;
                case 409:
                    result = "Пользователь с таким именем существует";
                    break;
                case 200:
                    result = "ok";
                    break;
                default:
                    result = "Произошли неполадки";
                    break;
            }
        }
    }
}
