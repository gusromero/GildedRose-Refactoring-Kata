using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrieItemName = "Aged Brie";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";


        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                UpdateQualitySingleItem(item);
            }
        }

        private void UpdateQualitySingleItem(Item item)
        {
            if (item.Name == SulfurasItemName)
            {
                return;
            }

            UpdateSellInSingleItem(item);

            if (item.Name != AgedBrieItemName && item.Name != BackstagePassItemName)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BackstagePassItemName)
                    {
                        if (item.SellIn < 10)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 5)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrieItemName)
                {
                    if (item.Name != BackstagePassItemName)
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private void UpdateSellInSingleItem(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
