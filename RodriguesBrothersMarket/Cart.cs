using System;
using System.Collections.Generic;
using System.Text;

namespace RodriguesBrothersMarket
{
    class Cart
    {
        public List<Invoice> cartList;

        public Cart()
        {
            this.cartList = new List<Invoice>();
        }
    }


}
