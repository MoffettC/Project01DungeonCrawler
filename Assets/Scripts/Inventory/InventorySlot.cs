using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler {
    public int id; //slot ID number

    private Inventory inv;
   
    // Use this for initialization
    void Start() {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();//Change name for mulitple inventories
    }

    public void OnDrop(PointerEventData eventData) {
        ItemData draggedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if (inv.items[id].ID == -1) {
            inv.items[draggedItem.slotNum] = new Item();
            inv.items[id] = draggedItem.item;
            draggedItem.slotNum = id;

        } else if (draggedItem.slotNum != id) {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotNum = draggedItem.slotNum; //setter?
            item.transform.SetParent(SlotController.slots[draggedItem.slotNum].transform);
            item.transform.position = SlotController.slots[draggedItem.slotNum].transform.position;

            Debug.Log("Dropped item coming from: " + draggedItem.slotNum + " | Switching to slot: " + id);

            draggedItem.slotNum = id;
            draggedItem.transform.SetParent(this.transform);
            draggedItem.transform.position = this.transform.position;

            inv.items[draggedItem.slotNum] = item.GetComponent<ItemData>().item;
            inv.items[id] = draggedItem.item;
        }
    }


}
