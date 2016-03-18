using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System;

public class InventoryDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start() {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public Item FetchItemByID(int id) {
        for (int i = 0; i < database.Count; i++) {
            if (database[i].ID == id) {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase() {
        for (int i = 0; i < itemData.Count; i++) {
            database.Add(new Item((int)itemData[i]["id"], (string)itemData[i]["title"], (int)itemData[i]["value"]
                        , (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defense"], 
                        (int)itemData[i]["stats"]["mobility"], itemData[i]["description"].ToString(), 
                        (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()));
        }
    }
}

public class Item {

    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defense { get; set; }
    public int Mobility { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, int power, int defense, int mobility, 
                                                string description, bool stackable, int rarity, string slug) {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Mobility = mobility;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>(slug);
    }

    public Item() {
        this.ID = -1;
    }
}
