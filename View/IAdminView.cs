using FlowerClient.Model;
using System.Collections.Generic;

namespace FlowerClient.View
{
    internal interface IAdminView
    {
        public void DisplayProducts(List<Product> products);
        public void LoadProducts();
        public void DisplayCurrentPhoto();
    }
}
