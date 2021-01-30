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
        public int priceT;

        public InvoiceLine(string productName, int productQnt, int priceT)
        {
            this.productName = productName;
            this.productQnt = productQnt;
            this.priceT = priceT;
        }
    }
}
