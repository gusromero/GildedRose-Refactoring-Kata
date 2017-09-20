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
                UpdateSellInSingleItem(item);
                UpdateQualitySingleItem(item);
            }
        }

        private void UpdateQualitySingleItem(Item item)
        {
            if (ItemIsSulfuras(item))
            {
                return;
            }


            if (!ItemIsAgedBrie(item) && !ItemIsBackstagePass(item))
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

                    if (ItemIsBackstagePass(item))
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
                if (!ItemIsAgedBrie(item))
                {
                    if (!ItemIsBackstagePass(item))
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                    else
                    {
                        item.Quality = 0;
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
            if (ItemIsSulfuras(item))
            {
                return;
            }

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

    }
}
