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
            if (barcode == null || !m_Products.ContainsKey(barcode))
            {
                m_Screen.ShowText("Product Not Found");
                return;
            }

            var product = m_Products[barcode];

            m_Screen.ShowText(product);
        }
    }
}