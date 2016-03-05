using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    private MapManager mapManager;
    private int maxItemType = 10;
    private GameObject[,] itemsAtLocation;

    public GameObject[] items;

	// Use this for initialization
	void Start () {
        mapManager = FindObjectOfType<MapManager>();
        GameObject[] items = new GameObject[maxItemType];
        GameObject[,] itemsAtLocation = new GameObject[mapManager.mapWidth, mapManager.mapHeight];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnItems()
    {
        for (int i = 0; i < mapManager.mapWidth; i++)
        {
            for (int j = 0; j < mapManager.mapHeight; j++)
            {
                int spawnChance = Random.Range(1, 100);
                int itemType = Random.Range(1, 10);
                if ((MapManager.occupiedTiles[i, j] == 0) && (spawnChance <= 10))
                {
                    MapManager.occupiedTiles[i, j] = 2;
                    GameObject newItem = Instantiate(items[itemType], new Vector2(i, j), Quaternion.identity) as GameObject;
                    itemsAtLocation[i, j] = newItem;
                }
            }
        }
    }

    public GameObject FindItem(int x, int y)
    {
        GameObject item = itemsAtLocation[x, y];
        return item;
    }


}
