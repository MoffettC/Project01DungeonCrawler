using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    private Inventory inventory;
    private MapManager mapManager;
    private int maxItemType = 10;

    public GameObject[,] itemsAtLocation;
    public GameObject[] items;
    public int[,] itemOccupiedTiles;

    void Awake() {

    }

    // Use this for initialization
    void Start() {
        inventory = FindObjectOfType<Inventory>();
        mapManager = FindObjectOfType<MapManager>();
        GameObject[] items = new GameObject[maxItemType];
        itemsAtLocation = new GameObject[mapManager.mapWidth, mapManager.mapHeight];

        SpawnItems();
    }
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnItems()
    {
        for (int y = 0; y < mapManager.mapHeight; y++)
        {
            for (int x = 0; x < mapManager.mapWidth; x++)
            {
                //ItemSpawnAlgorithm();
                int spawnChance = Random.Range(1, 100);
                int itemType = Random.Range(0, 2);
                //Debug.Log(i + " " + j);
                if ((MapManager.occupiedTiles[x, y] == 0) && (spawnChance <= 5))
                {
                    Debug.Log("Creating map item");
                    MapManager.occupiedTiles[x, y] = 3;
                    itemsAtLocation[x, y] = Instantiate(inventory.AddItemToMap(ItemSpawnAlgorithm()), new Vector2(x, y), Quaternion.identity) as GameObject;
                    //itemsAtLocation[x, y] = Instantiate(items[itemType], new Vector2(x, y), Quaternion.identity) as GameObject;
                    itemsAtLocation[x, y].transform.SetParent(transform, false);
                    
                }
            }
        }
    }

    int ItemSpawnAlgorithm()
    {

        //Spawn rate of various quality items
        //Returns item id to give to GenerateItems()
        return 1;
    }


    public GameObject FindItem(int x, int y)
    {
        GameObject item = itemsAtLocation[x, y];
        //AddItem(item.ID); 
        return item;
    }

 
}
