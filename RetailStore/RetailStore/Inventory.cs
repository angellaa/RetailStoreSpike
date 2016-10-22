using System.Collections.Generic;

namespace RetailStore
{
    public class Inventory
    {
        public Inventory(Dictionary<string, string> products)
        {
            Products = products;
        }

        public Dictionary<string, string> Products { get; }

        public bool ProductIsAbsent(string barcode)
        {
            return barcode == null || !Products.ContainsKey(barcode);
        }

        public string FindProduct(string barcode)
        {
            return Products[barcode];
        }
    }
}