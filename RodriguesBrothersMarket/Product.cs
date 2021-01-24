using System;
using System.Collections.Generic;
using System.Text;

namespace RodriguesBrothersMarket
{
    class Product
    {
        public string productName;
        public int productQnt;
        public int price;

        public Product(string productName, int productQnt, int price)
        {
            this.productName = productName;
            this.productQnt = productQnt;
            this.price = price;
        }
    }
}
