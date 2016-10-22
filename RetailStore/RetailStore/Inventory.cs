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
    }
}