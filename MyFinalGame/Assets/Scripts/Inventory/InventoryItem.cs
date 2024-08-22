public class InventoryItem
{
    public ItemData ItemData { get; private set; }
    public int Count { get; private set; }
    public float Durability { get; private set; }
    public float MaxCount => ItemData.MaxCountInSlot;

    public InventoryItem(ItemData itemData, int count = 1, float durability = 1f)
    {
        ItemData = itemData;
        Durability = durability;
        Count = count;
    }
}
