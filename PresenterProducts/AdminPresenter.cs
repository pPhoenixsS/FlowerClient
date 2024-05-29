using FlowerClient.Additions;
using FlowerClient.model;
using FlowerClient.Model;
using FlowerClient.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlowerClient.PresenterProducts
{
    internal class AdminPresenter : IAdminPresenter
    {
        IAdminView view;
        Product model;
        string result;

        public AdminPresenter(IAdminView view)
        {
            this.view = view;
            this.model = new Product();
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task AddProduct(string Name, string Kind, string Description, double Price, int Count, List<string> Images) // добавление продукта
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            model.Name = Name;
            model.Kind = Kind;
            model.Description = Description;
            model.Price = Price;
            model.Count = Count;
            model.Images = Images;

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            using var multipartContent = new MultipartFormDataContent();

            // Добавляем основные поля продукта
            multipartContent.Add(new StringContent(Name), "Name");
            multipartContent.Add(new StringContent(Kind), "Kind");
            multipartContent.Add(new StringContent(Description), "Description");
            multipartContent.Add(new StringContent(Price.ToString()), "Price");
            multipartContent.Add(new StringContent(Count.ToString()), "Count");

            // Добавляем изображения
            foreach (var imagePath in Images)
            {
                var fileStream = File.OpenRead(imagePath);
                var fileContent = new StreamContent(fileStream);
                // тип содержимого для изображений
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png"); // или "image/jpeg" в зависимости от типа изображений
                multipartContent.Add(fileContent, "Images", Path.GetFileName(imagePath));
            }

            // Отправляем запрос с основными данными и изображениями
            var response = await httpClient.PostAsync("http://localhost:5001/addproduct", multipartContent);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект Post
                    var product = JsonConvert.DeserializeObject<Product>(data);

                    result = "ok";
                    break;
                default:
                    result = "ошибка";
                    break;
            }
        }

        public async Task DeleteProduct(int id) // удаление продукта
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.DeleteAsync("http://localhost:5001/deleteproduct/" + id.ToString());

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    result = "ok";
                    break;
                default:
                    result = "ошибка";
                    break;
            }
        }

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
    }
}
