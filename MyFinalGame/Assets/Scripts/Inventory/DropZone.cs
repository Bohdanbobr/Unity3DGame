using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        var draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable == null)
            return;

        draggable.SetNextDropZone(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        var draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable == null)
            return;

        draggable.SetNextDropZone(null);
    }
}

