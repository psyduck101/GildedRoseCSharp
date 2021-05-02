using GildedRoseProgram.Interfaces;
using System.Collections.Generic;

namespace GildedRoseProgram.Model.Processors
{
    internal class LegendaryItemProcessor : IItemProcessor
    {
        public bool IsDefaultProcessor => false;
        public IEnumerable<string> ItemTypes => new[] { "sulfuras, hand of ragnaros" };

        public void UpdateQuality(Item item)
        {
        }
    }
}
