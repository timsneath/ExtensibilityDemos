using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public class Product
    {
        public Product(int sku, string productName, decimal pricePerUnit)
        {
            this.SKU = sku;
            this.ProductName = productName;
            this.PricePerUnit = pricePerUnit;
        }

        public int SKU { get; set; }
        public string ProductName { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}
