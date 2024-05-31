﻿using System.Collections.Generic;

namespace FlowerClient.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public List<string> Images { get; set; }

        public List<byte[]> ImagesByte { get; set; }
    }
}
