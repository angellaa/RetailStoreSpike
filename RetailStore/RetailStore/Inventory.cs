using System.Collections.Generic;

namespace RetailStore
{
    public class Inventory
    {
        public Inventory(Dictionary<string, string> products)
        {
            Products = products;
        }

        private Dictionary<string, string> Products { get; }

        public string FindProduct(string barcode)
        {
            return ProductNotFound(barcode) ? null : Products[barcode];
        }

        private bool ProductNotFound(string barcode)
        {
            return barcode == null || !Products.ContainsKey(barcode);
        }
    }
}