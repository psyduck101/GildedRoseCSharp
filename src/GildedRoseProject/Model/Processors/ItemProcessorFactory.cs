using GildedRoseProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GildedRoseProgram.Model.Processors
{
    public class ItemProcessorFactory : IItemProcessorFactory
    {
        protected IItemProcessor DefaultProcessor { get; set; }
        protected IDictionary<string, IItemProcessor> ItemProcessors { get; }
        protected IDictionary<string, Type> ItemProcessorTypes { get; } //mapping multiple types on same processor, to avoid duplicate invoices

        public ItemProcessorFactory()
        {
            ItemProcessors = new Dictionary<string, IItemProcessor>();
            ItemProcessorTypes = new Dictionary<string, Type>();
            LoadProcessors();
        }

        protected virtual void LoadProcessors()
        {
            var itemProcTypes = Assembly.GetExecutingAssembly().GetTypes().Where(tp => typeof(IItemProcessor).IsAssignableFrom(tp) && !tp.IsInterface);

            foreach (var itemProcType in itemProcTypes)
            {
                var processor = (IItemProcessor)Activator.CreateInstance(itemProcType);
                ItemProcessors.Add(processor.GetType().Name, processor);

                if (processor.IsDefaultProcessor)
                    DefaultProcessor = processor;
                else
                {
                    foreach (var itemType in processor.ItemTypes)
                        ItemProcessorTypes[itemType] = processor.GetType();
                }
            }
        }

        public IItemProcessor GetItemProcessor(string itemName)
        {
            if (ItemProcessorTypes.TryGetValue(itemName.ToLower(), out Type processorType))
                return ItemProcessors.TryGetValue(processorType.Name, out IItemProcessor processor)
                ? processor
                : throw new NotImplementedException($"{itemName} type is not supported");
            else
                return DefaultProcessor;
        }
    }
}
