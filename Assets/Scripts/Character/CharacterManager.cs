using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{
    public GameObject playerCharacter;
    public int spawnX;
    public int spawnY;

    private MapManager mapManager;
    private GameObject player;
    private bool hasSpawned = false;

    // Use this for initialization
    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();

        FindOpenSpot();
    }

    void FindOpenSpot()
    {
    //Debug.Log("Spawning Player");
    for (int i = 0; i < mapManager.mapWidth; i++)
        {
         for (int j = 0; j < mapManager.mapHeight; j++)
            {
                //Debug.Log("wallTile: "+ i + j + " " + tileMap.Walkable(i, j));
                if ((hasSpawned == false) && (MapManager.wallTiles[i, j] == 0))
                {
                SpawnPlayer(i, j);
                break;
                }
            }
        }
    }

    void SpawnPlayer(int i, int j)
    {
        player = Instantiate(playerCharacter, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
        player.name = "playerCharacter";
        //player.transform.parent = this.transform;
        hasSpawned = true;
        spawnX = i;
        spawnY = j;
    }

   
}
