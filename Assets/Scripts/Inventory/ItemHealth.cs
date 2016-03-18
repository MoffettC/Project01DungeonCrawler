using UnityEngine;
using System.Collections;

public class ItemHealth : ItemData, IUseItem {

   
    public void useItem() {
        Debug.Log("Use Item Health Invoked");
        //AddItem(GetComponent<ItemData>().item.ID);
        //Either use on pick up or add to inventory
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
