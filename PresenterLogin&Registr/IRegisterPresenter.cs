using System.Threading.Tasks;

namespace FlowerClient.presenter
{
    internal interface IRegisterPresenter
    {
        public Task Register(string email, string pass);
        public string ResultAsync { get; set; }
    }
}
