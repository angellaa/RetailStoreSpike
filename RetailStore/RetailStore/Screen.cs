namespace RetailStore
{
    public class Screen
    {
        public void ShowText(string text) => Text = text;

        public string Text { get; set; }

        public void ShowProduct(string product)
        {
            ShowText(product);
        }

        public void ShowProductNotFound()
        {
            ShowText("Product Not Found");
        }
    }
}