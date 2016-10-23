namespace RetailStore
{
    public class Screen
    {
        public string Text { get; private set; }

        public void ShowPrice(decimal price)
        {
            Text = $"${price}";
        }

        public void ShowTotalPrice(decimal totalPrice)
        {
            Text = $"OnTotal: ${totalPrice}";
        }

        public void ShowInvalidBarcode()
        {
            Text = "Invalid barcode: please try to scan the product again.";
        }

        internal void ShowProductNotFound(string barcode)
        {
            Text = $"Product not found for barcode {barcode}";
        }

        public void ShowNoSaleInProgress()
        {
            Text = "No sale in progress. Please try scanning a product.";
        }
    }
}