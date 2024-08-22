using UnityEngine;

public static class InventoryHelper
{
    public static bool CanPutInSlot(InventorySlot slot, InventoryItem item)
    {
        if ((slot.SlotType & item.ItemData.SlotType) == 0)
            return false;
        if (slot.IsEmpty)
            return true;
        return false;
    }

    public static void PrintSlots(InventorySlot[] Slots)
    {
        for (int i = 0; i < Slots.Length; ++i)
        {
            Debug.Log($"{Slots[i].Item?.ItemData?.Name ?? "None"} {Slots[i].IsEmpty}");
        }
    }
}