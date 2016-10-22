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
            if (m_Inventory.ProductIsAbsent(barcode))
            {
                m_Screen.ShowProductNotFound();
                return;
            }

            var product = m_Inventory.FindProduct(barcode);

            m_Screen.ShowProduct(product);
        }
    }
}