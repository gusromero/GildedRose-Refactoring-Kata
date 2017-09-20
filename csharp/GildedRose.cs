using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrieItemName = "Aged Brie";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";

        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (!ItemIsSulfuras(item))
                {
                    UpdateSellInSingleItem(item);
                    UpdateQualitySingleItem(item);
                }
            }
        }

        private void UpdateQualitySingleItem(Item item)
        {
            if (!ItemIsAgedBrie(item) && !ItemIsBackstagePass(item))
            {
                IncrementQualityDelimited(item, -1);
            }
            else
            {
                IncrementQualityDelimited(item, 1);

                if (ItemIsBackstagePass(item))
                {
                    if (item.SellIn < 10)
                    {
                        IncrementQualityDelimited(item, 1);
                    }

                    if (item.SellIn < 5)
                    {
                        IncrementQualityDelimited(item, 1);
                    }
                }
            }

            if (ItemHasExpired(item))
            {
                if (!ItemIsAgedBrie(item))
                {
                    if (!ItemIsBackstagePass(item))
                    {
                        IncrementQualityDelimited(item, -1);
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncrementQualityDelimited(item, 1);
                }
            }
        }

        private bool ItemHasExpired(Item item)
        {
            return item.SellIn < 0;
        }


        private void UpdateSellInSingleItem(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private bool ItemIsSulfuras(Item item)
        {
            return item.Name == SulfurasItemName;
        }

        private bool ItemIsAgedBrie(Item item)
        {
            return item.Name == AgedBrieItemName;
        }

        private bool ItemIsBackstagePass(Item item)
        {
            return item.Name == BackstagePassItemName;
        }

        private void IncrementQualityDelimited(Item item, int delta)
        {
            var newQuality = Math.Max(MinQuality, Math.Min(MaxQuality, item.Quality + delta));
            item.Quality = newQuality;
        }

    }
}
