using FlowerClient.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.Additions
{
    internal static class RefreshToken
    {
        private static string result;

        public static string ResultAsync
        {
            get => result;
            private set => result = value;
        }

        public static async Task<bool> Refresh() // обновить токен
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("FingerPrint", Header.headers.FingerPrint.ToString());
            httpClient.DefaultRequestHeaders.Add("RefreshToken", Header.headers.RefreshToken.ToString());

            var response = await httpClient.GetAsync("http://localhost:5000/refresh");

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных
                    var responseData = JsonConvert.DeserializeObject<Header>(data);

                    // Обновление заголовков
                    Header.headers.AccessToken = responseData.AccessToken;
                    Header.headers.RefreshToken = responseData.RefreshToken;

                    // Сохраняем заголовки
                    SaveHeaders.SaveHeaderFieldsToFile(Header.headers, "C:/Users/arish/Documents/GitHub/FlowerClient/Data/HeadersForSafety.txt");

                    result = "ok";
                    return true;
                default:
                    result = "ошибка";
                    return false;
            }
        }

        public static async Task CheckAndRefreshTokenIfNeeded() // проверяем нужно ли обновление токена
        {
            DateTime? tokenExpiryTime = TokenLifetime.Lifetime();
            if (tokenExpiryTime == null || TokenIsExpired(tokenExpiryTime.Value))
            {
                await Refresh();
            }
        }

        private static bool TokenIsExpired(DateTime tokenExpiryTime) // проверяем истекло ли время жизни токена
        {
            return DateTime.Now >= tokenExpiryTime;
        }
    }
}