using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.presenter
{
    internal interface IRegisterPresenter
    {
        public Task Register(string email, string pass);
        public string ResultAsync { get; set; }
    }
}
