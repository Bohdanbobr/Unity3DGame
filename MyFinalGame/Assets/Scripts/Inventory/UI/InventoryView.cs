using Project;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventorySlotView prefab;
    [SerializeField] private Transform parent;
    private void Start()
    {
        var slots = ProjectContext.Instance.InventoryService.Slots;
        int index = 1;
        foreach (var slot in slots)
        {
            var view = Instantiate(prefab, parent);
            view.name = $"{index++}";
            view.SetSlot(slot);
        }

    }
}
