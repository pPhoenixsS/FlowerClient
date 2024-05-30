using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface ICartPresenter
    {
        public string ResultAsync { get; set; }
        public Task<List<CartItem>> BuyProductsWitnBonuses(int bonuses);
        public Task<List<CartItem>> AllProductsInCart();
        public Task<Bonus> BonusesForBuy();
        public Task<Product> OneProduct(int id);
        public Task AddProductToCart(int id, int countBuyProduct);
    }
}
