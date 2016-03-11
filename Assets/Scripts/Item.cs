using UnityEngine;
using System.Collections;

public interface IUseItem
{
    void useItem();
}

public class Item : MonoBehaviour {

    public enum itemType {health, mana, strength, speed}
    public itemType item;
    public int itemID;
    public string itemName;
    public string itemDesc;

}



