using FlowerClient.Additions;
using FlowerClient.Model;
using FlowerClient.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlowerClient.model;

namespace FlowerClient.PresenterProducts
{
    internal class CartPresenter: ICartPresenter
    {
        ICartView view;
        string result;

        public CartPresenter(ICartView view)
        {
            this.view = view;
        }

        public string ResultAsync { get => result; set => value = result; }

        public async Task<List<CartItem>> BuyProductsWitnBonuses(int bonuses) // купить продукты, используя бонусы (если есть)
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5001/buy/" + bonuses.ToString());

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект List<CartItem>
                    var productsBuy = JsonConvert.DeserializeObject<List<CartItem>>(data);

                    result = "ok";
                    return productsBuy;
                default:
                    result = "ошибка";
                    break;
            }

            return null;
        }

        public async Task<List<CartItem>> AllProductsInCart() // все продукты в корзине
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5002/cart");

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект List<CartItem>
                    var productsInCart = JsonConvert.DeserializeObject<List<CartItem>>(data);

                    result = "ok";
                    return productsInCart;
                default:
                    result = "ошибка";
                    break;
            }

            return null;
        }

        public async Task<Product> OneProduct(int id) // вытащить один продукт по айди
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

                    result = "ok";
                    return product;
                default:
                    result = "ошибка";
                    break;
            }

            return null;
        }

        public async Task AddProductToCart(int id, int countBuyProduct) // добавление продукта в корзину (изменение и удаление тоже)
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var body = new
            {
                productId = id,
                count = countBuyProduct,
            };

            string jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5002/cart", content);

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект CartItem
                    var cartItem = JsonConvert.DeserializeObject<List<CartItem>>(data);

                    result = "ok";
                    break;
                default:
                    result = "ошибка";
                    break;
            }
        }

        public async Task<Bonus> BonusesForBuy() // получить количество бонусов
        {
            // Проверить и обновить токен при необходимости
            await RefreshToken.CheckAndRefreshTokenIfNeeded();

            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Header.headers.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5003/bonus");

            int statusCode = (int)response.StatusCode;

            switch (statusCode)
            {
                case 200:
                    // Получение данных из ответа
                    var data = await response.Content.ReadAsStringAsync();

                    // Десериализация JSON данных в объект Bonus
                    var bonuses = JsonConvert.DeserializeObject<Bonus>(data);

                    result = "ok";
                    return bonuses;
                default:
                    result = "ошибка";
                    break;
            }

            return null;
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
    }
}
