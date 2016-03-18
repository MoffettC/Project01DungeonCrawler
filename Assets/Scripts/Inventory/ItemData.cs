using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IDragHandler, IEndDragHandler, 
                                                    IPointerDownHandler {
    public int slotNum;
    public int amount;

    private Tooltip tooltip;
    private Inventory inv;
    private Vector2 offset;
    private Vector3 screenPoint;

	// Use this for initialization
	void Start () {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }

    //public void OnBeginDrag(PointerEventData eventData) {
    //    if (item != null) {
    //        //Offset so drag point is not centered on item
    //        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
    //        //Ensures that item is on top of UI
    //        this.transform.SetParent(this.transform.parent.parent.parent.parent);
    //        this.transform.position = eventData.position;
    //        GetComponent<CanvasGroup>().blocksRaycasts = false;
    //    }
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
       // offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);

        //screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //offset = screenPoint - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.SetParent(SlotController.slots[slotNum].transform.parent.parent.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //transform.position = curPosition;

        //transform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(SlotController.slots[slotNum].transform);
        transform.position = SlotController.slots[slotNum].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }



    //public void OnPointerEnter(PointerEventData eventData) {
    //    tooltip.Activate(item);
    //}

    //public void OnPointerExit(PointerEventData eventData) {
    //    tooltip.Deactivate();
    //}
}
