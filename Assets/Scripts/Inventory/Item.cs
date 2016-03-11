using UnityEngine;
using System.Collections;

public interface IUseItem
{
    void useItem();
}

//Transfer to Item class under ItemDB
public class Item : MonoBehaviour {

    public enum itemType {health, mana, strength, speed}
    public itemType item;
    public int itemID;
    public string itemName;
    public string itemDesc;

}



