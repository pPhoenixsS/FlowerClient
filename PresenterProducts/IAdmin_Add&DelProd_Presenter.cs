using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface IAdmin_Add_DelProd_Presenter
    {
        public Task AddProduct(string Name, string Kind, string Description, double Price, int Count, Array Images);
        public Task DeleteProduct(int id);
        public string ResultAsync { get; set; }
    }
}
