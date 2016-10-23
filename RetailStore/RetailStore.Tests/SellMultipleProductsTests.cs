using System.Collections.Generic;
using NUnit.Framework;

namespace RetailStore.Tests
{
    public class SellMultipleProductsTests
    {
        private Screen m_Screen;
        private RetailStore m_RetailStore;

        [SetUp]
        public void SetUp()
        {
            var inventory = new Inventory(new Dictionary<string, Product>
            {
                { "1", new Product(8.50m) },
                { "2", new Product(12.36m) },
                { "3", new Product(65.13m) },
            });

            m_Screen = new Screen();
            m_RetailStore = new RetailStore(m_Screen, inventory);
        }

        [Test]
        public void SellMultipleProducts()
        {
            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnBarcode("2");
            m_RetailStore.OnBarcode("3");
            m_RetailStore.Total();

            Assert.That(m_Screen.Text, Is.EqualTo("$85.99"));
        }
    }
}