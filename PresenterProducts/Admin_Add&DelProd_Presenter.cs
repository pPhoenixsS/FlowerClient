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
using System.Xml.Linq;

namespace FlowerClient.PresenterProducts
{
    internal class Admin_Add_DelProd_Presenter : IAdmin_Add_DelProd_Presenter
    {
        IAdminView view;
        Product model;
        string result;

        public Admin_Add_DelProd_Presenter(IAdminView view)
        {
            this.view = view;
            this.model = new Product();
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task AddProduct(string Name, string Kind, string Description, double Price, int Count, Array Images) // добавление продукта
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

            var body = new
            {
                Name = model.Name,
                Kind = model.Kind,
                Description = model.Description,
                Price = model.Price,
                Count = model.Count,
                Images = model.Images,
            };

            string jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5001/addproduct", content);

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
    }
}
