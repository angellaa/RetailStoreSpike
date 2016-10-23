namespace RetailStore
{
    public class Product
    {
        public decimal price;

        public Product(decimal price)
        {
            this.price = price;
        }

        public string PriceAsText => $"${price}";
    }
}