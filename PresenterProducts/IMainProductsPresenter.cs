using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface IMainProductsPresenter
    {
        public Task<List<Product>> AllProducts();
        public Task OneProduct(int id);
        public string ResultAsync { get; set; }
    }
}
