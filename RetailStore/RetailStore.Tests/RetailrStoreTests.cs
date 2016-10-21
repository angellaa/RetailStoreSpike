﻿using NUnit.Framework;

namespace RetailStore.Tests
{
    public class RetailStoreTests
    {
        [Test]
        public void ShowOneProduct()
        {
            var screen = new Screen();
            var retailStore = new RetailStore(screen);

            retailStore.OnBarcode("123456");

            Assert.That(screen.Text, Is.EqualTo("$12.34"));
        }

        [Test]
        public void ShowASecondProduct()
        {
            var screen = new Screen();
            var retailStore = new RetailStore(screen);

            retailStore.OnBarcode("123457");

            Assert.That(screen.Text, Is.EqualTo("$1564.34"));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("012345")]
        public void ProductNotFound(string barcode)
        {
            var screen = new Screen();
            var retailStore = new RetailStore(screen);

            retailStore.OnBarcode(barcode);

            Assert.That(screen.Text, Is.EqualTo("Product Not Found"));
        }
    }
}
