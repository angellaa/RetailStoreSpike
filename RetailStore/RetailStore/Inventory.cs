using System.Collections.Generic;

namespace RetailStore
{
    public class Inventory
    {
        public Inventory(Dictionary<string, Product> products)
        {
            Products = products;
        }

        private Dictionary<string, Product> Products { get; }

        public Product FindProduct(string barcode)
        {
            return ProductNotFound(barcode) ? null : Products[barcode];
        }

        private bool ProductNotFound(string barcode)
        {
            return barcode == null || !Products.ContainsKey(barcode);
        }
    }
}