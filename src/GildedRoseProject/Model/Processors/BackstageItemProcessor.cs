using GildedRoseProgram.Interfaces;
using System.Collections.Generic;

namespace GildedRoseProgram.Model.Processors
{
    internal class BackstageItemProcessor : IItemProcessor
    {
        public bool IsDefaultProcessor => false;

        public IEnumerable<string> ItemTypes => new[] { "backstage passes to a tafkal80etc concert" };

        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;


            if (item.Quality < 50)
            {
                if (item.SellIn <= 10)
                    item.Quality++;
                if (item.SellIn <= 5)
                    item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }
}
