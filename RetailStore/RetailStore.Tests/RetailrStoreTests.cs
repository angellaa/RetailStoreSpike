using Moq;
using NUnit.Framework;

namespace RetailStore.Tests
{
    public class RetailStoreTests
    {
        [Test]
        public void EmptyScreen()
        {
            var screen = Mock.Of<IScreen>(x => x.Text == "");
            new RetailStore(screen);

            Assert.That(screen.Text, Is.EqualTo(""));
        }
    }

    public interface IScreen
    {
        string Text { get; }
    }

    public class RetailStore
    {
        public RetailStore(IScreen screen)
        {            
        }
    }
}
