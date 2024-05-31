using FlowerClient.Model;
using FlowerClient.PresenterProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerClient.View
{
    internal interface ICartView
    {
        public void LoadProducts();
        public void DisplayProducts(List<CartItem> productsBuy);
        public Task BonusesCount();
        public Task SumPrice(List<CartItem> productsBuy);
        public Task DeleteNullProducts();
        public void InjectPresenter(ICartPresenter presenter);
    }
}
