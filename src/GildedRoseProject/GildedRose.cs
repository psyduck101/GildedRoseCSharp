using GildedRoseProgram.Interfaces;
using GildedRoseProgram.Model;
using System;
using System.Collections.Generic;

namespace GildedRoseProgram
{
    public class GildedRose
    {
        protected IItemProcessorFactory ItemProcessorFactory { get; private set; }
        IList<Item> Items;
        public GildedRose(IList<Item> Items, IItemProcessorFactory itemProcessorFactory)
        {
            this.Items = Items ?? throw new ArgumentNullException(nameof(Items));
            ItemProcessorFactory = itemProcessorFactory ?? throw new ArgumentNullException(nameof(itemProcessorFactory));
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                var processor = ItemProcessorFactory.GetItemProcessor(item.Name);
                processor.UpdateQuality(item);
            }
        }
    }
}
