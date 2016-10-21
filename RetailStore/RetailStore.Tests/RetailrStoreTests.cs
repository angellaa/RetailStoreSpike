using NUnit.Framework;

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
    }
}
