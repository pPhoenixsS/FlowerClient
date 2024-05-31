using FlowerClient.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    public interface ICartPresenter
    {
        public string ResultAsync { get; set; }
        public Task<List<CartItem>> BuyProductsWitnBonuses(int bonuses);
        public Task<List<CartItem>> AllProductsInCart();
        public Task<Bonus> BonusesForBuy();
        public Task<Product> OneProduct(int id);
        public Task AddProductToCart(int id, int countBuyProduct);
        public Task DeleteProduct(int id);
        public Task<List<Product>> AllProducts();
    }
}
