using UnityEngine;

namespace Project
{
    public interface IDataService
    {
        ItemData[] Items { get; }
    }

    public class DataService : IDataService
    {
        public ItemData[] Items { get; }



        public DataService(ItemsConfig itemsConfig)
        {
            Items = itemsConfig.items;
        }
    }
}