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
            var inventory = new Inventory(new Dictionary<string, string>
            {
                { "123456", "$12.34" },
                { "123457", "$1564.34" },
            });

            m_Screen = new Screen();
            m_RetailStore = new RetailStore(m_Screen, inventory);
        }

        [Test]
        public void SellOneProduct()
        {
            m_RetailStore.OnBarcode("123456");

            Assert.That(m_Screen.Text, Is.EqualTo("$12.34"));
        }

        [Test]
        public void SellASecondProduct()
        {
            m_RetailStore.OnBarcode("123457");

            Assert.That(m_Screen.Text, Is.EqualTo("$1564.34"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void InvalidBarcode(string barcode)
        {
            m_RetailStore.OnBarcode(barcode);

            Assert.That(m_Screen.Text, Is.EqualTo("Invalid barcode: please try to scan the product again."));
        }

        [Test]
        public void ProductNotFound()
        {
            m_RetailStore.OnBarcode("012345");

            Assert.That(m_Screen.Text, Is.EqualTo("Product not found for barcode 012345"));
        }
    }
}
