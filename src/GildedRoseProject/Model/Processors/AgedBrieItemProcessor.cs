using GildedRoseProgram.Interfaces;
using System.Collections.Generic;

namespace GildedRoseProgram.Model.Processors
{
    internal class AgedBrieProcessor : IItemProcessor
    {
        public bool IsDefaultProcessor => false;
        public IEnumerable<string> ItemTypes => new[] { "aged brie" };

        public void UpdateQuality(Item item)
        {
            IncreaseQuality(item);

            item.SellIn--;

            if (item.SellIn < 0)
                IncreaseQuality(item);
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;
        }
    }
}
