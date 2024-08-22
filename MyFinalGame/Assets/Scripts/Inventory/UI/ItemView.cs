using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private Draggable draggable;
    private InventorySlot slot;
    InventorySlotView slotView;

    private void Awake()
    {
        draggable.OnEndDragEvent += Draggable_OnEndDragEvent;
    }

    private void Draggable_OnEndDragEvent(DropZone dropZone)
    {
        if (dropZone == null)
            return;

        var slotView = dropZone.GetComponent<InventorySlotView>();
        if (slotView == null)
            return;

        slotView.Slot.SwapSlotItems(slot);
    }

    public void SetItem(InventorySlot inventorySlot, InventorySlotView slotView)
    {
        this.slotView = slotView;
        slot = inventorySlot;
        var itemData = inventorySlot.Item.ItemData;
        icon.sprite = itemData.Icon;
        Name.text = itemData.Name;
    }
}