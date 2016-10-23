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
        public void AllProductsFound()
        {
            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnBarcode("2");
            m_RetailStore.OnBarcode("3");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("OnTotal: $85.99"));
        }

        [Test]
        public void AllProductsFound_SecondSale()
        {
            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnTotal();

            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnBarcode("2");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("OnTotal: $20.86"));
        }

        [Test]
        public void SomeProductsNotFound()
        {
            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnBarcode("2-NotFound");
            m_RetailStore.OnBarcode("3");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("OnTotal: $73.63"));
        }

        [Test]
        public void NoProductsFound()
        {
            m_RetailStore.OnBarcode("1-NotFound");
            m_RetailStore.OnBarcode("2-NotFound");
            m_RetailStore.OnBarcode("3-NotFound");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("OnTotal: $0"));
        }

        [Test]
        public void NoSaleInProgress()
        {
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("No sale in progress. Please try scanning a product."));
        }

        [Test]
        public void NoSaleInProgress_SecondSale()
        {
            m_RetailStore.OnBarcode("1");
            m_RetailStore.OnTotal();

            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("No sale in progress. Please try scanning a product."));
        }
    }
}