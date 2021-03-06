using GildedRoseProgram.Interfaces;
using System.Collections.Generic;

namespace GildedRoseProgram.Model.Processors
{
    internal class ConjuredItemProcessor : IItemProcessor
    {

        public bool IsDefaultProcessor => false;

        public IEnumerable<string> ItemTypes => new[] { "conjured mana cake" };

        public void UpdateQuality(Item item)
        {
            if (item.Quality > 1)
                item.Quality-=2;
            else if(item.Quality == 1)
                item.Quality--;

            item.SellIn--;

            if (item.SellIn < 0)
            {
                if (item.Quality > 1)
                    item.Quality -= 2;
                else if (item.Quality == 1)
                    item.Quality--;
            }
        }
    }
}
