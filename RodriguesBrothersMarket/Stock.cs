using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RodriguesBrothersMarket
{
    [Serializable]
    class Stock
    {
        public List<Product> productList;

        public Stock()
        {
            this.productList = new List<Product>();
        }

        //Metodos:

        //Para criar novo produto e gravar na lista de produtos:
        public Product CreateProduct(ProductCategory productCategory, string productName, int productQnt, int price)
        {
            Product newProduct = new Product(productCategory, productName, productQnt, price);
            this.productList.Add(newProduct);
            return newProduct;
        }

        //Método para Apagar um Produto:
        public bool DeleteProductFromList(string productName)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                if (this.productList[i].productName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    this.productList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
        // Método Limpar Stock:
        public bool ClearStock()
        {
            this.productList.Clear();
            return true;
        }

        //Metodo apenas para referência
        public override string ToString()
        {
            string result = "|     TIPO DE PRODUTO     |     NOME ARTIGO     |     QUANTIDADE     |    PREÇO     |" + "\n";
            foreach (Product s in this.productList)
            {
                result += s.productCategory + "     |     " + s.productName + "     |     " + s.productQnt + "     |     " + s.price + "\n";
            }
            return result;
        }

        //Método para selecionar o produto a adicionar ao carrinho:
        public Product SelectProduct(string productName, int productQnt)
        {
            foreach (Product p in this.productList)
            {
                if (p.productName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null;
        }

        //Método para gravar lista de stock:
        public void SaveToFileStock()
        {
            string path = Directory.GetCurrentDirectory();

            string fileName = "/Stock.txt";

            using (StreamWriter streamWriter = new StreamWriter(path + fileName, false))
            {
                foreach (Product item in this.productList)
                {
                    item.Serialize(streamWriter);
                }
            }
        }

        public void ReadFromFileStock()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "/Stock.txt";

            try
            {
                using (StreamReader streamReader = new StreamReader(path + fileName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        productList.Add(Product.ReadLine(streamReader));
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}
