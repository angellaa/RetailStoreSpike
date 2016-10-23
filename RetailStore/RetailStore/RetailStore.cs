namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;
        private readonly Inventory m_Inventory;

        public RetailStore(Screen screen, Inventory inventory)
        {
            m_Screen = screen;
            m_Inventory = inventory;
        }

        public void OnBarcode(string barcode)
        {
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
                m_Screen.ShowProduct(product);
            }
        }

        private static bool InvalidBarcode(string barcode)
        {
            return string.IsNullOrEmpty(barcode);
        }
    }
}