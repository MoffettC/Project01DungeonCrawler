using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public GameObject[,] room;
    public GameObject character;
    public float tileSize = 1f;

    private int x1;
    private int y1;
    private int x2;
    private int y2;
    public Vector2 center;

    public Room(int x, int y, int width, int height){
        x1 = x;
        x2 = x + width;
        y1 = y;
        y2 = y + height;
        center = new Vector2(((x1 + x2) / 2), ((y1 + y2) / 2));
     }


    public GameObject CreateRoom(GameObject prefab)
    {
        if (!prefab)
            Debug.LogWarning("Unable to find TilePrefab in your Resources folder.");

        GameObject Room = new GameObject();
        Room.name = "Room";
        room = new GameObject[x2, y2];

        for (int i = x1; i < x2; i++){
            for (int j = y1; j < y2; j++){             
                GameObject floorTile = Instantiate(prefab, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
                floorTile.transform.parent = Room.transform;
                floorTile.name = "floorTile" + i + j;
                room[i, j] = floorTile;
                RemoveWallTiles(i, j);
                //GameObject playerChar = Instantiate(character, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
            }
        }
        return Room;
    }

    //Need to actually remove tiles and not use value as moveable/nonmoveable
    public void RemoveWallTiles(int i, int j) {
        TileMap.wallTiles[i, j] = 0;
        Debug.Log(TileMap.wallTiles[i, j]);
    }


    public bool Intersect(Room room)
    {
        return (x1 <= room.x2 && x2 >= room.x1 &&
            y1 <= room.y2 && room.y2 >= room.y1);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
