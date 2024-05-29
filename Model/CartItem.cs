using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.Model
{
    public class CartItem
    {
        public Product BuyProduct { get; set; }
        public int CountForBuy { get; set; }
    }
}
