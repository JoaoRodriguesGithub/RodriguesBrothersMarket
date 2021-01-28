﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RodriguesBrothersMarket
{
    enum ProductCategory
    {
        Frozen,

        Shelf,

        Can,
    }

    class Product
    {
        public ProductCategory productCategory;
        public string productName;
        public int productQnt;
        public int price;

        public Product(ProductCategory productCategory, string productName, int productQnt, int price)
        {
            this.productCategory = productCategory;
            this.productName = productName;
            this.productQnt = productQnt;
            this.price = price;
        }

        public void Serialize(StreamWriter writer)
        {
            writer.Write(this.productCategory.ToString());
            writer.Write(",");
            writer.Write(this.productName);
            writer.Write(",");
            writer.Write(this.productQnt);
            writer.Write(",");
            writer.Write(this.price);
            writer.Write("\n");
        }

        public static Product ReadLine(StreamReader reader)
        {
            string txtLine = reader.ReadLine();

            ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), txtLine.Split(",")[0]);
            string productName = txtLine.Split(",")[1];
            int productQnt = int.Parse(txtLine.Split(",")[2]);
            int price = int.Parse(txtLine.Split(",")[3]);

            return new Product(category, productName, productQnt, price);
        }

        public static ProductCategory ConvertCategory(string category)
        {
            if (category.Equals("congelados", StringComparison.OrdinalIgnoreCase))
            {
                return ProductCategory.Frozen;
            }

            if (category.Equals("prateleira", StringComparison.OrdinalIgnoreCase))
            {
                return ProductCategory.Shelf;
            }

            if (category.Equals("enlatados", StringComparison.OrdinalIgnoreCase))
            {
                return ProductCategory.Can;
            }

            throw new EntryPointNotFoundException();
        }
    }
}
