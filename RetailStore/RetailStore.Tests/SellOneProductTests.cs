using System.Collections.Generic;
using NUnit.Framework;

namespace RetailStore.Tests
{
    public class SellOneProductTests
    {
        private Screen m_Screen;
        private RetailStore m_RetailStore;

        [SetUp]
        public void SetUp()
        {
            var inventory = new Inventory(new Dictionary<string, Product>
            {
                { "123456", new Product(12.34m) },
                { "123457", new Product(1564.34m) },
            });

            m_Screen = new Screen();
            m_RetailStore = new RetailStore(m_Screen, inventory);
        }

        [Test]
        public void ScanOneProduct()
        {
            m_RetailStore.OnBarcode("123456");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("Total: $12.34"));
        }

        [Test]
        public void ScanASecondProduct()
        {
            m_RetailStore.OnBarcode("123457");
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("Total: $1564.34"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void InvalidBarcode(string barcode)
        {
            m_RetailStore.OnBarcode(barcode);
            m_RetailStore.OnTotal();

            Assert.That(m_Screen.Text, Is.EqualTo("Total: $0"));
        }

        [Test]
        public void ProductNotFound()
        {
            m_RetailStore.OnBarcode("NotFound");
            m_RetailStore.OnTotal();

        }
    }
}
