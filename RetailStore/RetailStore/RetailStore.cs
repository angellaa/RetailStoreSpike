using System.Collections.Generic;
using System.Linq;

namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;
        private readonly Inventory m_Inventory;
        private readonly List<Product> m_ScannedProducts = new List<Product>();
        private int m_AttemptedScans;

        public RetailStore(Screen screen, Inventory inventory)
        {
            m_Screen = screen;
            m_Inventory = inventory;
        }

        public void OnBarcode(string barcode)
        {
            m_AttemptedScans++;

            if (InvalidBarcode(barcode))
            {
                m_Screen.ShowInvalidBarcode();
                return;
            }

            var product = m_Inventory.FindProduct(barcode);

            if (product == null)
            {
                m_Screen.ShowProductNotFound(barcode);
            }
            else
            {
                m_Screen.ShowPrice(product.Price);
                m_ScannedProducts.Add(product);
            }
        }

        public void OnTotal()
        {
            if (m_AttemptedScans == 0)
            {
                m_Screen.ShowNoSaleInProgress();
                return;
            }

            m_Screen.ShowTotalPrice(m_ScannedProducts.Sum(p => p.Price));

            m_ScannedProducts.Clear();
            m_AttemptedScans = 0;
        }

        private static bool InvalidBarcode(string barcode)
        {
            return string.IsNullOrEmpty(barcode);
        }
    }
}