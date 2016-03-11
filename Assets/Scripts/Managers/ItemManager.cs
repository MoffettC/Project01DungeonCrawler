using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    private MapManager mapManager;
    private int maxItemType = 10;

    public GameObject[,] itemsAtLocation;
    public GameObject[] items;
    public int[,] itemOccupiedTiles;

    void Awake() {

    }

    // Use this for initialization
    void Start() {
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
                    //Debug.Log("x: "+ x + "y: " + y);
                    MapManager.occupiedTiles[x, y] = 3;
                    //GenerateItems();
                    itemsAtLocation[x, y] = Instantiate(items[itemType], new Vector2(x, y), Quaternion.identity) as GameObject;
                    itemsAtLocation[x, y].transform.SetParent(transform, false);
                    
                }
            }
        }
    }

    void ItemSpawnAlgorithm()
    {
        //Spawn rate of various quality items
        //Returns item id to give to GenerateItems()
    }

    void GenerateItems(int id)
    {
        //Call database of items and generate item to spawn with qualities according to database of items
    }

    public GameObject FindItem(int x, int y)
    {
        GameObject item = itemsAtLocation[x, y];
        return item;
    }


}
