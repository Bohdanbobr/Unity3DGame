using Project;
using UnityEngine;

public interface IInventoryService
{
    InventorySlot[] Slots { get; }
    void AddItem(InventoryItem inventoryItem);
    
}

public class InventoryService : IInventoryService
{
    

    public InventorySlot[] Slots { get; }
    private const int InventorySize = 10;
    

    public InventoryService(IDataService dataService)
    {
        var items = dataService.Items;
        Slots = new InventorySlot[InventorySize];
        for (int i = 0; i < InventorySize; ++i)
        {
            Slots[i] = new InventorySlot(default, InventorySlotType.All);
        }
        
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        for (int i = 0; i < Slots.Length; ++i)
        {
            if (InventoryHelper.CanPutInSlot(Slots[i], inventoryItem))
            {
                Slots[i].Item = inventoryItem;
                break;
            }
            Debug.Log("wwwTrying to add item: " + inventoryItem.ItemData.Name + Slots[i] + Slots[i].Item);
        }
        
    }


}