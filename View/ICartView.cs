using FlowerClient.Model;
using System.Collections.Generic;

namespace FlowerClient.View
{
    internal interface ICartView
    {
        public void LoadProducts();
        public void DisplayProducts(List<CartItem> productsBuy);
        public void BonusesCount();
        public void SumPrice(List<CartItem> productsBuy);
        public void DeleteNullProducts();
    }
}
