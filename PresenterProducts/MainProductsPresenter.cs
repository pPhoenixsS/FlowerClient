using FlowerClient.Additions;
using FlowerClient.model;
using FlowerClient.Model;
using FlowerClient.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal class MainProductsPresenter : IMainProductsPresenter
    {
        IMainProductsView view;
        string result;

        public MainProductsPresenter(IMainProductsView view)
        {
            this.view = view;
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task<List<Product>> AllProducts() // все продукты
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5001/products");

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект List<Product>
                    var products = JsonConvert.DeserializeObject<List<Product>>(data);

                    // Преобразование изображений из массива строк (приходит с сервера) в массив байтов
                    foreach (var product in products)
                    {
                        if (product.Images != null && product.Images.Any())
                        {
                            var images = new List<byte[]>();

                            foreach (var imageString in product.Images)
                            {
                                // Преобразование строки в массив байтов
                                byte[] imageBytes = Convert.FromBase64String(imageString);
                                images.Add(imageBytes);
                            }

                            product.ImagesByte = images;
                        }
                    }

                    result = "ok";
                    return products;
                default:
                    result = "ошибка";
                    break;
            }

            return null;
        }

        public async Task OneProduct(int id) // один продукт
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5001/product/" + id.ToString());

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект Product
                    var product = JsonConvert.DeserializeObject<Product>(data);
                    result = "ok";
                    break;
                default:
                    result = "ошибка";
                    break;
            }
        }

        public string GetRole()
        {
            return TokenParameters.GetRoleFromToken();
        }
    }
}
