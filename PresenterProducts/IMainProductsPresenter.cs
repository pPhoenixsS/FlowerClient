using FlowerClient.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface IMainProductsPresenter
    {
        public Task<List<Product>> AllProducts();
        public string ResultAsync { get; set; }
        public string GetRole();
        public Task AddProductToCart(int id, int countBuyProduct);
    }
}
