using System.Collections.Generic;

namespace csharp.Model.Processors
{
    public class AgedBrieProcessor : IItemProcessor
    {
        public AgedBrieProcessor()
        {
        }

        public bool IsDefaultProcessor => false;
        public IEnumerable<string> ItemTypes => new[] { "aged brie" };

        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < 50)
                item.Quality++;
        }
    }
}
