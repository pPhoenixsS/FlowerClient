using FlowerClient.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface IAdminPresenter
    {
        public Task AddProduct(string Name, string Kind, string Description, double Price, int Count, List<string> Images);
        public Task DeleteProduct(int id);
        public Task<List<Product>> AllProducts();
        public string ResultAsync { get; set; }
    }
}
