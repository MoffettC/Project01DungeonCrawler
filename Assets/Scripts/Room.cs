using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public GameObject[,] room;
    public float tileSize = 1f;

    private int x1;
    private int y1;
    private int x2;
    private int y2;

    public Room(int x, int y, int width, int height){
        x1 = x;
        x2 = x + width;
        y1 = y;
        y2 = y + height;
     }


    public void CreateRoom(GameObject prefab)
    {
        if (!prefab)
            Debug.LogWarning("Unable to find TilePrefab in your Resources folder.");
        GameObject Room = new GameObject();
        room = new GameObject[x2, y2];

        for (int i = x1; i < x2; i++)
        {
            for (int j = y1; j < y2; j++)
            {
               // Debug.Log("x: " + i);
                //Debug.Log("y: " + j);
                
                GameObject floorTile = Instantiate(prefab, new Vector3(i * tileSize, j * tileSize, 0), Quaternion.identity) as GameObject;
                //wallTile.transform.parent = Room.transform;
                room[i, j] = floorTile;
            }
        }
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
