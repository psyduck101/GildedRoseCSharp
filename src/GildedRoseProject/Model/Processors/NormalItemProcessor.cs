using System.Collections.Generic;

namespace csharp.Model.Processors
{
    public class NormalItemProcessor : IItemProcessor
    {
        public NormalItemProcessor()
        {
        }

        public bool IsDefaultProcessor => true;
        public IEnumerable<string> ItemTypes => new[] { "+5 Dexterity Vest" };

        public void UpdateQuality(Item item)
        {
            if(item.Quality > 0)
            item.Quality--;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality >= 1)
                item.Quality--;
        }
    }
}
