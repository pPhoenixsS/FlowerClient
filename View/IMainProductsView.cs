﻿using FlowerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerClient.View
{
    internal interface IMainProductsView
    {
        public void DisplayProducts(List<Product> products);
        public void LoadProducts();
        public bool ValidateTextBoxValue(TextBox textBox, int maxValue);
    }
}
