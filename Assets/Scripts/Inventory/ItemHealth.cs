using UnityEngine;
using System.Collections;

public class ItemHealth : Item, IUseItem {

    public itemType type = itemType.health;
    
   
    public void useItem() {
        Debug.Log("Use Item Health Invoked");
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
