using System.Collections.Generic;

namespace csharp.Model
{
    public interface IItemProcessor
    {
        bool IsDefaultProcessor { get; }
        IEnumerable<string> ItemTypes { get; }
        void UpdateQuality(Item item);
    }
}
