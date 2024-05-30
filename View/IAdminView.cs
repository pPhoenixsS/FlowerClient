using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.View
{
    internal interface IAdminView
    {
        public void DisplayProducts(List<Product> products);
        public void LoadProducts();
        public void DisplayCurrentPhoto();
    }
}
