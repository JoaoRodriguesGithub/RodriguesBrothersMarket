using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace RodriguesBrothersMarket
{
    [Serializable]
    class Finance: Invoice
    {
        public List<Invoice> allSalesList;

        public Finance()
        {
            allSalesList = new List<Invoice>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            foreach (var invoice in allSalesList)
            {
                result.Append(invoice.ToString());
            }

            return result.ToString();
        }

        public void AddInvoice(Invoice invoice)
        {
            this.allSalesList.Add(invoice);
        }

        public void SaveFinalInvoice()
        {
            string fileName = "TodasAsFaturas.txt";

            if (File.Exists(fileName))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(fileName);
            }

            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, this);

            fileStream.Close();

        }

        public static Finance ReadFinalInvoice()
        {
            string fileName = "TodasAsFaturas.txt";
            
            if (File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter f = new BinaryFormatter();

                Finance l = f.Deserialize(fileStream) as Finance;
                fileStream.Close();
                return l;
            }
            else
            {
                return new Finance();
            }
        }
    }
}
