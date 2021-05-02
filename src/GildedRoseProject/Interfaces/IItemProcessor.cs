using GildedRoseProgram.Model;
using System.Collections.Generic;

namespace GildedRoseProgram.Interfaces
{
    public interface IItemProcessor
    {
        bool IsDefaultProcessor { get; }
        IEnumerable<string> ItemTypes { get; }
        void UpdateQuality(Item item);
    }
}
