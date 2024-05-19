using FlowerClient.Additions;
using FlowerClient.model;
using FlowerClient.view;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.presenter
{
    internal class LoginPresenter : ILoginPresenter
    {
        ILoginView view;
        LoginModel model;
        string result;

        public LoginPresenter(ILoginView view)
        {
            this.view = view;
            this.model = new LoginModel();
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task Login(string email, string pass)
        {
            using HttpClient httpClient = new HttpClient();

            string FingerPrint = Guid.NewGuid().ToString();
            Header.headers.FingerPrint = FingerPrint;

            httpClient.DefaultRequestHeaders.Add("FingerPrint", Header.headers.FingerPrint.ToString());

            var body = new
            {
                email = email,
                password = pass,
            };

            string jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5000/login", content);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 400:
                    result = "Неверный логин или пароль";
                    // BadRequest
                    break;
                case 409:
                    result = "Пользователя с таким именем нет";
                    //NotFound
                    break;
                case 404:
                    result = "Пользователя с таким именем нет";
                    //NotFound
                    break;
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект headers
                    var _headers = JsonConvert.DeserializeObject<Header>(data);

                    // Сохранение данных сессии в заголовках для последующих запросов
                    Header.headers.RefreshToken = _headers.RefreshToken;
                    Header.headers.AccessToken = _headers.AccessToken;

                    result = "ok";
                    break;
                default:
                    result = "Произошли неполадки";
                    break;
            }

            // Относительный путь к файлу HeadersForSafety.txt
            string relativePath = "Data/HeadersForSafety.txt";

            // Формирование полного пути к файлу
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            // Использование полного пути в методе сохранения заголовков
            SaveHeaders.SaveHeaderFieldsToFile(Header.headers, fullPath);
        }
    }
}
