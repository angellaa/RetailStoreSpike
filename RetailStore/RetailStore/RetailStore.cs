namespace RetailStore
{
    public class RetailStore
    {
        private readonly Screen m_Screen;

        public RetailStore(Screen screen)
        {
            m_Screen = screen;
        }

        public void OnBarcode(string barcode)
        {
            m_Screen.ShowText("$12.34");
        }
    }
}