using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Transform defaultParent;
    private DropZone dropZone;
    public event Action<DropZone> OnEndDragEvent;

    public void SetNextDropZone(DropZone dropZone)
    {
        this.dropZone = dropZone;
    }
    private void Awake()
    {
        defaultParent = transform.parent;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        transform.parent = transform.root;

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.parent = defaultParent;
        transform.localPosition = Vector3.zero;
        OnEndDragEvent?.Invoke(dropZone);
    }
}

