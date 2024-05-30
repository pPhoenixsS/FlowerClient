﻿using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.PresenterProducts
{
    internal interface IMainProductsPresenter
    {
        public Task<List<Product>> AllProducts();
        public string ResultAsync { get; set; }
        public string GetRole();
        public Task AddProductToCart(int id, int countBuyProduct);
    }
}
