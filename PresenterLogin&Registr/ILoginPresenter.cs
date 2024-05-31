using System.Threading.Tasks;

namespace FlowerClient.presenter
{
    internal interface ILoginPresenter
    {
        public Task Login(string email, string pass);
        public string ResultAsync { get; set; }
    }
}
