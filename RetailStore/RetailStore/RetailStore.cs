using System.Collections.Generic;

namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;
        private readonly Dictionary<string, string> m_Products;

        public RetailStore(Screen screen, Inventory inventory)
        {
            m_Screen = screen;
            m_Products = inventory.Products ?? new Dictionary<string, string>();
        }

        public void OnBarcode(string barcode)
        {
            if (ProductIsAbsent(barcode))
            {
                m_Screen.ShowProductNotFound();
                return;
            }

            var product = FindProduct(barcode);

            m_Screen.ShowProduct(product);
        }

        private bool ProductIsAbsent(string barcode)
        {
            return barcode == null || !m_Products.ContainsKey(barcode);
        }

        private string FindProduct(string barcode)
        {
            return m_Products[barcode];
        }
    }
}