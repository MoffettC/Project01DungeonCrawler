using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameObject gamePanel;
    GameObject inventoryPanel;
    GameObject slotPanel;

    InventoryDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public List<Item> items = new List<Item>();
    //public List<GameObject> slots = new List<GameObject>();


    void Start() {
        DontDestroyOnLoad(transform.gameObject);
        database = GetComponent<InventoryDatabase>();
        SlotController.slotCount = 29;

        inventoryPanel = GameObject.Find("Inventory Panel"); //Change name for mulitple inventories

        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < SlotController.slotCount - 8; i++) {
            items.Add(new Item());
            SlotController.slots.Add(Instantiate(inventorySlot));
            SlotController.slots[i].name = "Inventory Slot " + i.ToString();
            SlotController.slots[i].GetComponent<InventorySlot>().id = i;
            SlotController.slots[i].transform.SetParent(slotPanel.transform, false);
        }

        //gamePanel = GameObject.Find("Game Panel");
        //slotPanel = gamePanel.transform.FindChild("Slot Panel").gameObject;
        //for (int i = (SlotController.slotCount - 8); i < SlotController.slotCount; i++) {
        //    items.Add(new Item());
        //    SlotController.slots.Add(Instantiate(inventorySlot));
        //    SlotController.slots[i].name = "Inventory 2 Slot " + i.ToString();
        //    SlotController.slots[i].GetComponent<InventorySlot>().id = i;
        //    SlotController.slots[i].transform.SetParent(slotPanel.transform, false);
        //}


        AddItem(0);
        AddItem(1);
        //Detects what units are in game panel. Redo this code to un-hardcode array
        //for (int i = 21; i < SlotController.slotCount; i++) {
         //       Debug.Log(SlotController.slots[i].GetComponentInChildren<ItemData>().item.Title);         
        //}

    }

    public void AddItem(int id) {
        Item itemToAdd = database.FetchItemByID(id);

        for (int i = 0; i < items.Count; i++) {
            if (items[i].ID == -1) {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.GetComponent<ItemData>().slotNum = i;

                itemObj.transform.SetParent(SlotController.slots[i].transform, false);      
                itemObj.transform.position = SlotController.slots[i].transform.position;
                //itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                Debug.Log("In slot: " + itemObj.GetComponent<ItemData>().slotNum + " with amount " + itemObj.GetComponent<ItemData>().amount
                     + " and item " + itemObj.GetComponent<ItemData>().item.Title);
                break;
            }
        }
    }

    public GameObject AddItemToMap(int id) {
        Item itemToAdd = database.FetchItemByID(id);
        GameObject itemObj;
        for (int i = 0; i < items.Count; i++) {
            if (items[i].ID == -1) {
                //items[i] = itemToAdd;
                itemObj = inventoryItem;
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                //itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;

                Debug.Log("In slot: " + itemObj.GetComponent<ItemData>().slotNum + " with amount " + itemObj.GetComponent<ItemData>().amount
                     + " and item " + itemObj.GetComponent<ItemData>().item.Title);
                return itemObj;
            } 
        }
        return null;

    }
}

public class SlotController {
    public static List<GameObject> slots = new List<GameObject>();
    public static int slotCount;
}