namespace csharp.Model.Processors
{
    public interface IItemProcessorFactory
    {
        IItemProcessor GetItemProcessor(string itemName);
    }
}