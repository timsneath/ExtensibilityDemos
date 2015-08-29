using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{

    public class Order
    {
        public class LineItem
        {
            public LineItem(int quantity, Product item)
            {
                this.Quantity = quantity;
                this.Item = item;
            }
            public int Quantity { get; set; }
            public Product Item { get; set; }
        }

        public List<LineItem> LineItems { get; set; }

        public Address ShippingAddress { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            foreach(LineItem l in LineItems)
            {
                str.AppendLine(String.Format($"{l.Quantity} of {l.Item.ProductName}"));
            }

            return str.ToString();
        }
    }
}
