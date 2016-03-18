using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IDropHandler
{    public int id; //slot ID number

    private Inventory inv;
    private ItemManager itemManager;
    private GameObject thisItem;
    private int dropSlot;

    // Use this for initialization
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();//Change name for mulitple inventories
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        //thisItem = gameObject.GetComponentInChildren<ItemData>() as GameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter" + eventData.pointerEnter.GetComponent<InventorySlot>().id);
        dropSlot = eventData.pointerEnter.GetComponent<InventorySlot>().id;
        //return eventData.pointerEnter.GetComponent<InventorySlot>().id;
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData draggedItemID = eventData.pointerDrag.GetComponent<ItemData>();
        GameObject draggedItem = eventData.pointerDrag.gameObject;
        Debug.Log("Item Swapping");

        if (SlotController.slots[dropSlot].transform.GetChild(0).GetComponentInChildren<ItemBlank>())
        {
            GameObject blankItem = Instantiate(itemManager.itemsList[0]);
            blankItem.transform.SetParent(SlotController.slots[id].transform);
            draggedItem.transform.SetParent(SlotController.slots[dropSlot].transform);
            Debug.Log("Item in Empty Slot " + dropSlot +" original slot: " + id);
            //inv.items[draggedItem.slotNum] = itemManager.itemsList[0];
            //inv.items[id] = draggedItem.item;
            //draggedItem.slotNum = id;

        }
        else if (draggedItemID.slotNum != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotNum = draggedItemID.slotNum; //setter?
            item.transform.SetParent(SlotController.slots[draggedItemID.slotNum].transform);
            item.transform.position = SlotController.slots[draggedItemID.slotNum].transform.position;

            Debug.Log("Dropped item coming from: " + draggedItemID.slotNum + " | Switching to slot: " + id);

            draggedItemID.slotNum = id;
            draggedItem.transform.SetParent(this.transform);
            draggedItem.transform.position = this.transform.position;

            SlotController.slots[draggedItemID.slotNum] = itemManager.itemsList[0];
            SlotController.slots[id] = draggedItem;
        }
    }


}
