using System;

public class InventorySlot
{
    public InventoryItem Item { get; set; }
    public InventorySlotType SlotType { get; set; }
    public bool IsEmpty => Item == null;
    public event Action OnSlotCganged;

    public InventorySlot(InventoryItem item, InventorySlotType slotType)
    {
        Item = item;
        SlotType = slotType;
    }

    public bool CanPutInSlot(InventoryItem item)
    {
        if (item == null)
            return true;
        if ((SlotType & item.ItemData.SlotType) == 0)
            return false;
        if (IsEmpty)
            return true;
        return true;
    }

    public void SwapSlotItems(InventorySlot slot)
    {
        if (CanPutInSlot(slot.Item) && slot.CanPutInSlot(Item))
        {
            var otherItem = slot.Item;
            slot.Item = Item;
            Item = otherItem;
            slot.OnSlotCganged?.Invoke();
            OnSlotCganged?.Invoke();
        }
    }
}