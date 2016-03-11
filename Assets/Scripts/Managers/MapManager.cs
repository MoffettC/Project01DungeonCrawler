using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public static int[,] wallTiles;
    public static int[,] occupiedTiles;
    public int mapWidth;
    public int mapHeight;

    private GameObject wallTile; 
    private float tileSize = 1f;
    private int maxRooms = 4;
    private int minRoomSize = 2;
    private int maxRoomSize = 10;

    //Implement later. Stores walkable tiles into a separate array
    //private bool notWalkable = true;
    //private bool[,] walkableArray;

    void Start()
    {
        //Creating Floor Tiles
        if (!wallPrefab)
            Debug.LogWarning("Unable to find TilePrefab in your Resources folder.");


        wallTiles = new int[mapWidth, mapHeight];
        occupiedTiles = new int[mapWidth, mapHeight];

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                {
                    wallTiles[x, y] = 1; //0 is open 1 occupied
                    occupiedTiles[x, y] = 1; 
                    // 0 free
                    // 1 environ/player occupied
                    // 2 enemy
                    // 3 item
                    //Debug.Log("Occupied Tiles set to 0 " + occupiedTiles[x, y]);
                }
            }
        }
        PlaceFloor();
        PlaceRooms(floorPrefab);

    }

    public void SetWalkable(int x, int y)
    {
        wallTiles[x, y] = 0;
        occupiedTiles[x, y] = 0;
        //Debug.Log("wallTiles: " + x + y + " " + wallTiles[x, y]);
        //Debug.Log("Walkable " + x + y + " " + Walkable(x, y));
    }

    //public bool Walkable(int x, int y)
    //{
    //    if (wallTiles[x, y] == 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public void PlaceFloor()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                if (wallTiles[x, y] == 1)
                {
                    wallTile = Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity) as GameObject;
                    wallTile.transform.parent = gameObject.transform;
                    wallTile.name = "Wall Tile" + x + y;
                }
            }
        }
    }

    //Removes tiles but still needs reworking.
    public void RemoveFloor(int x, int y)
    {
        GameObject gObject;
        gObject = GameObject.Find("Wall Tile" + x + y);
        Destroy(gObject);
        occupiedTiles[x, y] = 0;
        //Vector2 tile = new Vector2(x, y);
        //for (int i = 0; i < mapHeight; i++)
        //{
        //    for (int j = 0; j < mapWidth; j++)
        //    {

        //    }
        //}
    }

    public void PlaceRooms(GameObject prefab)
    {
        Room[] rooms = new Room[maxRooms];
        Vector2[] roomCenter = new Vector2[maxRooms];


        for (int i = 0; i < maxRooms; i++)
        {
            int w = minRoomSize + Random.Range(1, maxRoomSize - minRoomSize);
            int h = minRoomSize + Random.Range(1, maxRoomSize - minRoomSize);
            int x = Random.Range(1, mapWidth - w - 1);
            int y = Random.Range(1, mapHeight - h - 1);

            //Create room
            Room newRoom = new Room(x, y, w, h);
            GameObject roomGameObject = newRoom.CreateRoom(prefab);

            rooms[i] = newRoom;
            roomCenter[i] = newRoom.center;

            if (i != 0)
            {
                Vector2 newCenter = roomCenter[i];
                Vector2 prevCenter = roomCenter[i - 1];
                //Vector2 prevCenter = rooms[rooms.Length - 1].center;
                HCorridor(newCenter.x, prevCenter.x, prevCenter.y, roomGameObject.transform);
                VCorridor(newCenter.y, prevCenter.y, newCenter.x, roomGameObject.transform);
            }
        }
    }


    public void HCorridor(float x1, float x2, float y, Transform room)
    {
        //Parenting corridor floor to corridor gameObject
        GameObject corridor = new GameObject();
        corridor.name = "Corridor Y" + (int)y;
        corridor.transform.parent = room.transform;

        int hX1 = (int)x1;
        int hX2 = (int)x2;
        int hY1 = (int)y;

        if (hX2 <= hX1)
        {
            int temp = hX1;
            hX1 = hX2;
            hX2 = temp;
        }
        for (int i = hX1; i <= hX2; i++)
        {
            GameObject floorTile = Instantiate(floorPrefab, new Vector3(i * tileSize, hY1 * tileSize, 0), Quaternion.identity) as GameObject;
            GameObject floorTile2 = Instantiate(floorPrefab, new Vector3(i * tileSize, (hY1 + 1) * tileSize, 0), Quaternion.identity) as GameObject;
            SetWalkable(i, hY1);
            SetWalkable(i, hY1 + 1);
            floorTile.transform.parent = corridor.transform;
            floorTile.name = "floorTile" + i + hY1;
            floorTile2.transform.parent = corridor.transform;
            floorTile2.name = "floorTile2" + i + hY1;
        }
    }

    public void VCorridor(float y1, float y2, float x, Transform room)
    {
        //Parenting corridor floor to corridor gameObject
        GameObject corridor = new GameObject();
        corridor.name = "Corridor X" + (int)x;
        corridor.transform.parent = room.transform;

        int vY1 = (int)y1;
        int vY2 = (int)y2;
        int vX1 = (int)x;

        if (vY2 < vY1)
        {
            int temp = vY1;
            vY1 = vY2;
            vY2 = temp;
        }
        for (int i = vY1; i <= vY2; i++)
        {
            GameObject floorTile = Instantiate(floorPrefab, new Vector3(vX1 * tileSize, i * tileSize, 0), Quaternion.identity) as GameObject;
            GameObject floorTile2 = Instantiate(floorPrefab, new Vector3((vX1 + 1) * tileSize, i * tileSize, 0), Quaternion.identity) as GameObject;
            SetWalkable(vX1, i);
            SetWalkable(vX1, i + 1);
            floorTile.transform.parent = corridor.transform;
            floorTile.name = "floorTile" + i + vX1;
            floorTile2.transform.parent = corridor.transform;
            floorTile2.name = "floorTile2" + i + vX1;
        }
    }

}