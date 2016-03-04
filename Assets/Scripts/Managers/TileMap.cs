using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public static int[,] wallTiles;
    public int isWall = 1;
    public GameObject wallTile;

    public int mapWidth;
    public int mapHeight;
    private float tileSize = 1f;
    private int maxRooms = 4;
    private int minRoomSize = 2;
    private int maxRoomSize = 10;


    public bool notWalkable = true;
    public bool[,] walkableArray;

    void Start()
    {
        //Creating Floor Tiles
        if (!wallPrefab)
            Debug.LogWarning("Unable to find TilePrefab in your Resources folder.");

        
        wallTiles = new int[mapWidth, mapHeight];
        walkableArray = new bool[mapWidth, mapHeight];

        for (int y = 0; y < mapHeight; y++){
            for (int x = 0; x < mapWidth; x++) {
                {   
                    wallTiles[x, y] = isWall;
                    Debug.Log(wallTiles[x, y]);
                }
            }
        }
        PlaceFloor();
        PlaceRooms(floorPrefab);
    }

    public bool Walkable(int x, int y) {
        if (wallTiles[x, y] == isWall) {
            return false;
        } else {
            return true;
        }
    }

    public void PlaceFloor() {
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                if (wallTiles[x, y] == isWall) {
                    wallTile = Instantiate(wallPrefab, new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity) as GameObject;
                    wallTile.transform.parent = gameObject.transform;
                    wallTile.name = "Wall Tile" + x + y;
                }
            }
        }
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

            if (i != 0) {
                Vector2 newCenter = roomCenter[i];
                Vector2 prevCenter = roomCenter[i - 1];
                //Vector2 prevCenter = rooms[rooms.Length - 1].center;
                //Debug.Log("NEWx1 " + newCenter.x);
                //Debug.Log("PREVx2 " + prevCenter.x);
                //Debug.Log("PREVy " + prevCenter.y);
                HCorridor(newCenter.x, prevCenter.x, prevCenter.y, roomGameObject.transform);
                VCorridor(newCenter.y, prevCenter.y, newCenter.x, roomGameObject.transform);
            } 
        }
    }


    public void HCorridor (float x1, float x2, float y, Transform room) {
        //Parenting corridor floor to corridor gameObject
        GameObject corridor = new GameObject();
        corridor.name = "Corridor Y" + (int)y;
        corridor.transform.parent = room.transform;

        int hX1 = (int)x1;
        int hX2 = (int)x2;
        int hY1 = (int)y;

        //Debug.Log("x1 " + hX1);
        //Debug.Log("x2 " + hX2);
        //Debug.Log("y " + hY1);

        if (hX2 <= hX1) {
            int temp = hX1;
            hX1 = hX2;
            hX2 = temp;
        }
        for (int i = hX1; i <= hX2; i++) {
            GameObject floorTile = Instantiate(floorPrefab, new Vector3(i * tileSize, hY1 * tileSize, 0), Quaternion.identity) as GameObject;
            GameObject floorTile2 = Instantiate(floorPrefab, new Vector3(i * tileSize, (hY1 + 1) * tileSize, 0), Quaternion.identity) as GameObject;
            floorTile.transform.parent = corridor.transform;
            floorTile.name = "floorTile" + i + hY1;
            floorTile2.transform.parent = corridor.transform;
            floorTile2.name = "floorTile2" + i + hY1;
        }
    }

    public void VCorridor(float y1, float y2, float x, Transform room) {
        //Parenting corridor floor to corridor gameObject
        GameObject corridor = new GameObject();
        corridor.name = "Corridor X" + (int)x;
        //corridor.transform.parent = room.transform;

        int vY1 = (int)y1;
        int vY2 = (int)y2;
        int vX1 = (int)x;

        //Debug.Log("x1 " + hX1);
        //Debug.Log("x2 " + hX2);
        //Debug.Log("y " + hY1);

        if (vY2 < vY1) {
            int temp = vY1;
            vY1 = vY2;
            vY2 = temp;
        }
        for (int i = vY1; i <= vY2; i++) {
            GameObject floorTile = Instantiate(floorPrefab, new Vector3(vX1 * tileSize, i * tileSize, 0), Quaternion.identity) as GameObject;
            GameObject floorTile2 = Instantiate(floorPrefab, new Vector3((vX1 + 1) * tileSize, i * tileSize, 0), Quaternion.identity) as GameObject;
            floorTile.transform.parent = corridor.transform;
            floorTile.name = "floorTile" + i + vX1;
            floorTile2.transform.parent = corridor.transform;
            floorTile2.name = "floorTile2" + i + vX1;
        }
    }

}