using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.View
{
    internal interface ICartView
    {
        public void LoadProducts();
        public void DisplayProducts(List<CartItem> productsBuy);
        public void BonusesCount();
        public void SumPrice(List<CartItem> productsBuy);
    }
}
