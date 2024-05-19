using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.model
{
    internal class Header
    {
        public string FingerPrint { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }

        public static Header headers = new Header();
    }
}
