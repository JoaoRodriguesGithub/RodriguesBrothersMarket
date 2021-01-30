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

        //Método para criar a Fatura final:
        public Invoice CreateFinalInvoice(string invoiceUserName, string customerName)
        {
            Invoice newInvoiceHeader = new Invoice(invoiceUserName, customerName);
            this.allSalesList.Add(newInvoiceHeader);

            return newInvoiceHeader;
        }

        //FOI NECESSARIO HERDAR ATRIBUTOS DO INVOICE PARA FAZER ESTE TO STRING:
        public override string ToString()
        {
            string result = "|     Nº FATURA     |     NOME CLIENTE     |    DATA    |" + "\n";
            foreach (Finance f in this.allSalesList)
            {
                result += f.invoiceNumber + "     |     " + f.customerName + "     |     " + f.invoiceDate + "\n";
            }
            return result;
        }


        public void SaveFinalInvoice()
        {
            string location = Directory.GetCurrentDirectory();
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

        public static Invoice ReadFinalInvoice()
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "TodasAsFaturas.txt";
            
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
