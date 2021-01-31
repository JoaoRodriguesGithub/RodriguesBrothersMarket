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
        public static int id = 0;

        public int invoiceNumber;
        public DateTime invoiceDate;
        public string customerName;
        public string userName;

        public List<InvoiceLine> invoiceList;

        public Invoice()
        {
            this.invoiceNumber = ++id;
            this.invoiceDate = DateTime.Now;
            this.invoiceList = new List<InvoiceLine>();
        }

        public override string ToString()
        {
            int total = 0;
            string result = $"NUMERO: {this.invoiceNumber}\n";
            result += $"DATA: {this.invoiceDate}\n";
            result += $"UTILIZADOR: {this.userName}\n";
            result += $"CLIENTE: {this.customerName}\n";

            result += " |    NOME ARTIGO     |     QUANTIDADE     |    PREÇO     |\n";
            foreach (InvoiceLine s in this.invoiceList)
            {
                result += $" | {s.productName}       | {s.productQnt}        | {s.priceT}      |\n";
                total += s.priceT;
            }

            result += "TOTAL: " + total + "\n";
            result += "\n";
            return result;
        }

        //Metodo para criar linha de fatura na lista de Fatura:
        public InvoiceLine CreateInvoiceLine(string productName, int productQnt, int priceT)
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

                fileStream.Close();
                return l;
            }
            else
            {
                return null;
            }
        }

    }
}
