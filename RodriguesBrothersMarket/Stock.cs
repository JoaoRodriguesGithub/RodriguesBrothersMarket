using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RodriguesBrothersMarket
{
    class Stock
    {
        public List<Product> productList;

        public Stock()
        {
            this.productList = new List<Product>();
        }

        //Metodos:

        //Para criar novo produto e gravar na lista de produtos:
        public Product CreateProduct(string productName, int productQnt, int price)
        {
            Product newProduct = new Product(productName, productQnt, price);
            this.productList.Add(newProduct);
            return newProduct;
        }

        //Método para Apagar um Produto:
        public bool DeleteProductFromList(string productName)
        {
            int indexToDelete = -1;
            for (int i = 0; i < productList.Count; i++)
            {
                if (this.productList[i].productName.ToLower().Equals(productName.ToLower()))
                {
                    indexToDelete = i;
                    return true;
                }
            }
            if (indexToDelete != -1)
            {
                this.productList.RemoveAt(indexToDelete);
            }
            return true;
        }
        // Método Limpar Stock:
        public bool ClearStock()
        {
            this.productList.Clear();
            return true;
        }

        //Método para gravar lista de stock:
        public void SaveToFileStock()
        {
            string path = Directory.GetCurrentDirectory();

            string fileName = "/Stock.txt";

            StreamWriter streamWriter = new StreamWriter(path + fileName, false);

            foreach (Product item in this.productList)
            {
                streamWriter.Write(item.productName + "," + item.productQnt + "," + item.price + "\n");
            }

            streamWriter.Close();
        }

    }
}
