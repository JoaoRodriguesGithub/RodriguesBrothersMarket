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
        public string invoiceUserName;

        public List<InvoiceLine> invoiceList;

        //Construtores
        public Invoice()
        {
            invoiceList = new List<InvoiceLine>();
        }

        public Invoice(string customerName, string invoiceUserName)
        {
            this.invoiceDate = DateTime.Now;
            this.invoiceNumber = 1;
            this.invoiceUserName = invoiceUserName;
            this.customerName = customerName;
        }

        //Método para criar linhas de fatura na lista a faturar:
        public InvoiceLine CreateInvoiceLine(string productName, int productQnt, int priceT)
        {
            InvoiceLine newInvoiceLine = new InvoiceLine(productName, productQnt, priceT);
            this.invoiceList.Add(newInvoiceLine);
            return newInvoiceLine;
        }

        //Metodo para ver o invoice line
        public override string ToString()
        {
            string result = "|     NOME PRODUTO     |     QUANTIDADE     |     PREÇO     |" + "\n";
            foreach (InvoiceLine s in this.invoiceList)
            {
                result += s.productName + "     |     " + s.productQnt + "     |     " + s.priceT + "\n";
            }
            return result;
        }

        public void SaveInvoice()
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
