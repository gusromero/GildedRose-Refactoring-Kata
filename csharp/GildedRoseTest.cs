﻿using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private IList<Item> _items;
        private GildedRose _app;

        private const string RandomItemName = "foo";
        private const string AgedBrieItemName = "Aged Brie";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";

        [SetUp]
        public void Setup()
        {
            _items = new List<Item> { };
        }
        [Test]
        public void foo()
        {
            var item = new Item { Name = RandomItemName, SellIn = 0, Quality = 0 } ;
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(RandomItemName, _items[0].Name);
        }

        [Test]
        public void SellInIsDecreased()
        {
            var item = new Item { Name = RandomItemName, SellIn = 1, Quality = 1 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].SellIn);
        }

        [Test]
        public void QualityIsDecreased()
        {
            var item = new Item { Name = RandomItemName, SellIn = 1, Quality = 1 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].Quality);
        }

        [Test]
        public void AfterSellInDateQualityDecreasesTwice()
        {
            var item = new Item { Name = RandomItemName, SellIn = 0, Quality = 2 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].Quality);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            var item = new Item { Name = RandomItemName, SellIn = 0, Quality = 0 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].Quality);
        }

        [Test]
        public void BeforeSellInDateAgedBrieQualityIncreasesSimple()
        {
            var item = new Item { Name = AgedBrieItemName, SellIn = 1, Quality = 0 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(1, _items[0].Quality);
        }

        [Test]
        public void AfterSellInDateAgedBrieQualityIncreasesDouble()
        {
            var item = new Item { Name = AgedBrieItemName, SellIn = 0, Quality = 0 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(2, _items[0].Quality);
        }

        [Test]
        public void QualityIsNeverMoreThanFifty()
        {
            var item = new Item { Name = AgedBrieItemName, SellIn = 0, Quality = 50 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(50, _items[0].Quality);
        }

        [Test]
        public void SulfurasQualityIsNeverDecreased()
        {
            var item = new Item { Name = SulfurasItemName, SellIn = 0, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(10, _items[0].Quality);
        }

        [Test]
        public void SulfurasSellInIsNeverDecreased()
        {
            var item = new Item { Name = SulfurasItemName, SellIn = 10, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(10, _items[0].Quality);
        }

        [Test]
        public void BeforeTenDaysBackstagePassQualityIncreasesSimple()
        {
            var item = new Item { Name = BackstagePassItemName, SellIn = 11, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(11, _items[0].Quality);
        }
        [Test]
        public void TenDaysOrLessBackstagePassQualityIncreasesDouble()
        {
            var item = new Item { Name = BackstagePassItemName, SellIn = 10, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(12, _items[0].Quality);
        }

        [Test]
        public void FiveDaysOrLessBackstagePassQualityIncreasesTriple()
        {
            var item = new Item { Name = BackstagePassItemName, SellIn = 5, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(13, _items[0].Quality);
        }

        [Test]
        public void ZeroDaysBackstagePassQualityDrops()
        {
            var item = new Item { Name = BackstagePassItemName, SellIn = 0, Quality = 10 };
            _items.Add(item);
            _app = new GildedRose(_items);

            _app.UpdateQuality();

            Assert.AreEqual(0, _items[0].Quality);
        }
    }
}
