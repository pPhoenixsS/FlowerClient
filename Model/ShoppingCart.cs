using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.Model
{
    public static class ShoppingCart // корзина пользователя
    {
        private static Dictionary<string, List<CartItem>> userCarts = new Dictionary<string, List<CartItem>>(); // словарь, ключ - email пользователя), значение — список объектов CartItem (представляющий корзину покупок пользователя)

        public static List<CartItem> GetUserCart(string email) // у каждого пользователя - своя корзина
        {
            if (userCarts.ContainsKey(email)) // если уже есть корзина у конкретного пользователя
            {
                return userCarts[email];
            }
            else // если еще нет корзины
            {
                var newCart = new List<CartItem>();
                userCarts[email] = newCart;
                return newCart;
            }
        }

        public static void AddProductToCart(string email, Product product, int countForBuy) // добавить товар в корзину
        {
            var cart = GetUserCart(email);

            // Ищем товар в корзине
            CartItem cartItem = null;

            foreach (var item in cart)
            {
                if (item.BuyProduct.Id == product.Id)
                {
                    cartItem.BuyProduct = item.BuyProduct;
                    break; // Прекращаем поиск, если нашли товар
                }
            }

            // Проверяем, найден ли товар в корзине
            if (cartItem != null)
            {
                cartItem.CountForBuy += countForBuy; // Если товар уже есть в корзине, увеличиваем количество
            }
            else
            {
                cart.Add(new CartItem { BuyProduct = product, CountForBuy = countForBuy }); // Если товара нет в корзине, добавляем его
            }
        }

        public static void RemoveProductFromCart(string email, Product product) // удаляем товар из корзины
        {
            var cart = GetUserCart(email);

            // Ищем товар в корзине
            CartItem cartItem = null;

            foreach (var item in cart)
            {
                if (item.BuyProduct.Id == product.Id)
                {
                    cartItem.BuyProduct = item.BuyProduct;
                    break; // Прекращаем поиск, если нашли товар
                }
            }

            if (cartItem != null)
            {
                cartItem.CountForBuy = 0;
                cart.Remove(cartItem); // Удаляем элемент из корзины
            }
        }

        public static void ClearCart(string email) // очищаем корзину
        {
            var cart = GetUserCart(email);
            cart.Clear();
        }
    }
}
