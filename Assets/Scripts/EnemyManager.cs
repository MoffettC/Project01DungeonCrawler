using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;

    private MapManager mapManager;
    private bool hasSpawned = false;

    // Use this for initialization
    void Start () {
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
                int spawnRate = Random.Range(1, 100);
                if ((hasSpawned == false) && (MapManager.wallTiles[i, j] == 0))
                {
                    if (spawnRate < 3)
                    {
                        SpawnEnemy(i, j);
                        return;
                    }
                }
            }
        }
    }

    void SpawnEnemy(int i, int j)
    {
        enemy = Instantiate(enemy, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
        enemy.name = "enemy";
        //player.transform.parent = this.transform;
        hasSpawned = true;
        //spawnX = i;
        //spawnY = j;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
