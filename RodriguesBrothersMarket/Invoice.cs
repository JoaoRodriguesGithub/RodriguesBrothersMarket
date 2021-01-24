using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace RodriguesBrothersMarket
{
    class Invoice : Product
    {
        public int invoiceNumber;
        public DateTime invoiceDate;
        public string customerName;
        //falta o nome do utilizador

        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, string productName, int productQnt, int price) : base(productName, productQnt, price)
        {

        }
        
    }
}
