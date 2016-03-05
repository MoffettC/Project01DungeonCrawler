using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public enum itemType {health, mana, strength, speed}
    public itemType item;
    public int itemID;
    public string itemName;
    public string itemDesc;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
