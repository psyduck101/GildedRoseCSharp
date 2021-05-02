namespace GildedRoseProgram.Interfaces
{
    public interface IItemProcessorFactory
    {
        IItemProcessor GetItemProcessor(string itemName);
    }
}