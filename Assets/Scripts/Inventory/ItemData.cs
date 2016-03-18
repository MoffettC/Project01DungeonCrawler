using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, 
                                                    IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    public int slotNum;
    public Item item;
    public int amount;

    private Tooltip tooltip;
    private Inventory inv;
    private Vector2 offset;

	// Use this for initialization
	void Start () {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }
	
    public void OnBeginDrag(PointerEventData eventData) {
        if (item != null) {
            //Offset so drag point is not centered on item
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            //Ensures that item is on top of UI
            this.transform.SetParent(this.transform.parent.parent.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (item != null) {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        this.transform.SetParent(SlotController.slots[slotNum].transform);
        this.transform.position = SlotController.slots[slotNum].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (item != null) {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.Deactivate();
    }
}
