using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace RodriguesBrothersMarket
{
    [Serializable]
    class Invoice
    {
        public int invoiceNumber;
        public DateTime invoiceDate;
        public string customerName;
        //falta o nome do utilizador

        public List<InvoiceLine> invoiceList;

        public Invoice()
        {
            invoiceList = new List<InvoiceLine>();
        }

        public override string ToString()
        {
            string result = "        NOME ARTIGO     |     QUANTIDADE     |    PREÇO     |" + "\n";
            foreach (InvoiceLine s in this.invoiceList)
            {
                result +=  s.productName + "        |                 " + s.productQnt + "     |                  " + s.priceT + "\n";
            }
            return result;
        }
        //Metodo para criar linha de fatura na lista de Fatura:
        public InvoiceLine CreateInvoiceLine(string productName, int productQnt, int priceT )
        {
            InvoiceLine newInvoiceLine = new InvoiceLine(productName, productQnt, priceT);
            this.invoiceList.Add(newInvoiceLine);
            return newInvoiceLine;
        }



        public void SaveInvoice()
        {
            try
            {
                string location = Directory.GetCurrentDirectory();
                string fileName = "Fatura.txt";

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
            catch (FileNotFoundException)
            {
            }
        
        }

        public static Invoice ReadInvoice()
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "Fatura.txt";
            if (File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter f = new BinaryFormatter();
              
                Invoice l = f.Deserialize(fileStream) as Invoice;
                return l;
                
                fileStream.Close();
            }
            else
            {
                return null;
            }
        }

    }
}
