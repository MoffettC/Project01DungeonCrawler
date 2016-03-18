using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {

    GameObject gamePanel;
    GameObject inventoryPanel;
    GameObject slotPanel;


    public GameObject inventorySlot;

    //private GameObject[] itemsList;
    private ItemManager itemManager;
    //public List<GameObject> slots = new List<GameObject>();


    void Start() {
        DontDestroyOnLoad(transform.gameObject);
        SlotController.slotCount = 29;

        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        inventoryPanel = GameObject.Find("Inventory Panel"); //Change name for mulitple inventories

        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < SlotController.slotCount; i++) {
            Debug.Log("Creating Slot");

            SlotController.slots.Add(Instantiate(inventorySlot));
            SlotController.slots[i].name = "Inventory Slot " + i.ToString();
            SlotController.slots[i].GetComponent<InventorySlot>().id = i;
            SlotController.slots[i].transform.SetParent(slotPanel.transform, false);

            GameObject blankItem = Instantiate(itemManager.itemsList[0]);
            blankItem.transform.SetParent(SlotController.slots[i].transform, false);
        }
        AddItem(1);
        AddItem(2);

    }


    public void AddItem(int id)
    {
        for (int i = 0; i < SlotController.slotCount; i++)
        {
            if (!SlotController.slots[i].transform.GetComponentInChildren<ItemData>())
            {
                
                GameObject itemObj = Instantiate(itemManager.itemsList[id]);
                //itemobj.GetComponent<ItemData>().item = itemtoadd;
                itemObj.GetComponent<ItemData>().slotNum = i;
                itemObj.transform.SetParent(SlotController.slots[i].transform, false);
                itemObj.transform.position = SlotController.slots[i].transform.position;

                SlotController.slots[i].transform.GetComponentInChildren<ItemBlank>().DestroyThis();
                //itemobj.getcomponent<image>().sprite = itemtoadd.sprite;
                //itemObj.name = itemToAdd.title;
                break;
            }
        }
    }


}

public class SlotController {
    public static List<GameObject> slots = new List<GameObject>();
    public static int slotCount;
}