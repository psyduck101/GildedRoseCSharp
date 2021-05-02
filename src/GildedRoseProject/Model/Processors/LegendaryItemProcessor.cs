using System.Collections.Generic;

namespace csharp.Model.Processors
{
    public class LegendaryItemProcessor : IItemProcessor
    {
        public LegendaryItemProcessor()
        {
        }

        public bool IsDefaultProcessor => false;
        public IEnumerable<string> ItemTypes => new[] { "sulfuras, hand of ragnaros" };

        public void UpdateQuality(Item item)
        {
        }
    }
}
