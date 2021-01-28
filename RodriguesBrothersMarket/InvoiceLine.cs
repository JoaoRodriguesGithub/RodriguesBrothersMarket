using System;
using System.Collections.Generic;
using System.Text;

namespace RodriguesBrothersMarket
{
    [Serializable]
    class InvoiceLine
    {
        //
        public string productName;
        public int productQnt;
        public int price;

        public InvoiceLine(string productName, int productQnt, int price)
        {
            this.productName = productName;
            this.productQnt = productQnt;
            this.price = price;
        }
    }
}
