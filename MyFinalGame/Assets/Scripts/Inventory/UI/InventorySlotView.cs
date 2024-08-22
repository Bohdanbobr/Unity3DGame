using UnityEngine;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private ItemView itemView;
    public InventorySlot Slot { get;  set; }
    public void SetSlot(InventorySlot slot)
    {
        Slot = slot;
        Slot.OnSlotCganged += DisplaySlot;
        DisplaySlot();


    }
    private void OnDestroy()
    {
        Slot.OnSlotCganged -= DisplaySlot;
    }
    public void DisplaySlot()
    {
        itemView.gameObject.SetActive(!Slot.IsEmpty);
        if (!Slot.IsEmpty)
            itemView.SetItem(Slot, this);
    }
}

