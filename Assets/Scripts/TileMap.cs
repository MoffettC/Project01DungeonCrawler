using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;


    public int x1;
    public int y1;
    public int x2;
    public int y2;

    public int mapWidth;
    public int mapHeight;
    public float tileSize = 1.28f;
    public int maxRooms = 1;
    public int minRoomSize = 3;
    public int maxRoomSize = 5;

    public GameObject[,] wallTiles;
    public bool notWalkable = true;
    public bool[,] walkableArray;

    void Start()
    {
        //Creating Floor Tiles
        if (!wallPrefab)
            Debug.LogWarning("Unable to find TilePrefab in your Resources folder.");

        GameObject wallTile = new GameObject();

        wallTiles = new GameObject[mapWidth, mapHeight];
        walkableArray = new bool[mapWidth, mapHeight];

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                {                                 
                    wallTile = Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity) as GameObject;
                    walkableArray[x, y] = notWalkable;
                    //floorTile = floorTiles[x, y];
                    //wallTiles[x, y] = wallTile;
                    //floorTiles[x, y].transform.parent = floorMap.transform;
                }
            }
        }     
        PlaceRooms(floorPrefab);
    }

    public void PlaceRooms(GameObject prefab)
    {
        Room[] rooms = new Room[maxRooms];
        //bool failed = false;

        for (int i = 0; i < maxRooms; i++)
        {
            int w = minRoomSize + Random.Range(1, maxRoomSize - minRoomSize);
            int h = minRoomSize + Random.Range(1, maxRoomSize - minRoomSize);
            int x = Random.Range(1, mapWidth - w - 1);
            int y = Random.Range(1, mapHeight - h - 1);

            //Create room
           Room newRoom = new Room(x, y, w, h);
           newRoom.CreateRoom(prefab);
           rooms[i] = newRoom;

            for (int j = x; j < x + w; j++){
                for (int k = y; k < y + h; k++) {
                    {
                        if (IsWalkable(j, k)) {
                            walkableArray[j, k] = false;
                            Debug.Log("Walkable at " + j + k);
                        }
                    }
                }
            }
        }
    }

    public bool IsWalkable(int x, int y)
    {
        if (x1 < 0 || y1 < 0 || x > mapWidth || y1 > mapHeight){
            if (walkableArray[x, y] = notWalkable){
                return false;
            }
            else{
                return true;
            }
        } else{
            Debug.Log("Coordinates out of bounds");
            return false;
        }
    }

}