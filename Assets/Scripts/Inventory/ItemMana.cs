using UnityEngine;
using System.Collections;

public class ItemMana : Item, IUseItem
{

    public itemType type = itemType.mana;


    public void useItem()
    {
        Debug.Log("Use Item Mana Invoked");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
