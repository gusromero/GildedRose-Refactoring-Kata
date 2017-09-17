using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private IList<Item> _items;
        private GildedRose _app;

        [SetUp]
        public void Setup()
        {
            _items = new List<Item> { };
        }
        [Test]
        public void foo()
        {
            var item = new Item { Name = "foo", SellIn = 0, Quality = 0 } ;
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual("foo", _items[0].Name);
        }

        [Test]
        public void SellInIsDecreased()
        {
            var item = new Item { Name = "foo", SellIn = 1, Quality = 1 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].SellIn);
        }
        [Test]
        public void QualityIsDecreased()
        {
            var item = new Item { Name = "foo", SellIn = 1, Quality = 1 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].Quality);
        }
    }
}
