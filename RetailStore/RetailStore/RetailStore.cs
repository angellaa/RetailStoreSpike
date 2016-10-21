using System.Collections.Generic;

namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;

        private readonly Dictionary<string, string> products = new Dictionary<string, string>
        {
            { "123456", "$12.34" },
            { "123457", "$1564.34" },
        };

        public RetailStore(Screen screen)
        {
            m_Screen = screen;
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