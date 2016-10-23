using System;

namespace RetailStore
{
    public class Screen
    {
        public string Text { get; private set; }

        public void ShowProduct(string product)
        {
            Text = product;
        }

        public void ShowProductNotFound()
        {
            Text = "Product Not Found";
        }

        internal void ShowProductNotFound(string barcode)
        {
            Text = $"Product not found for barcode {barcode}";
        }
    }
}