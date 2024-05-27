using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.Model
{
    internal class Product
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Array Images { get; set; }
    }
}
