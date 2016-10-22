using System.Collections.Generic;

namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;

        private readonly Dictionary<string, string> products;

        public RetailStore(Screen screen, Dictionary<string, string> products)
        {
            m_Screen = screen;
            this.products = products;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == null || !products.ContainsKey(barcode))
            {
                m_Screen.ShowText("Product Not Found");
                return;
            }

            var product = products[barcode];

            m_Screen.ShowText(product);
        }
    }
}