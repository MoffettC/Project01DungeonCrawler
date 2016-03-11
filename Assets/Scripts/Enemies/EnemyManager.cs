using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public int maxArray = 20;

    private GameObject enemySearched;
    private GameObject[] enemyArray = new GameObject[20];
    private int enemyIndex = 0;
    private MapManager mapManager;
    private bool hasSpawned = false;

    // Use this for initialization
    void Start () {
        mapManager = FindObjectOfType<MapManager>();
        FindOpenSpot();
        FindOpenSpot();
        FindOpenSpot();
        FindOpenSpot();
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
                if ((MapManager.wallTiles[i, j] == 0) && (spawnRate < 3))
                {
                    if ((i > 0) && SearchEnemyArray(i, j))
                    {
                        SpawnEnemy(i, j);
                        return;
                    } else {
                        SpawnEnemy(i, j);
                        return;
                    }
                }
            }
        }
    }

    void SpawnEnemy(int x, int y)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        enemyArray[enemyIndex] = newEnemy;
        enemyArray[enemyIndex].name = enemyIndex + " enemy01Type";
        enemyArray[enemyIndex].transform.SetParent(this.transform, false);
       // Debug.Log("eArray Transform: " + enemyArray[enemyIndex].transform.position);
        enemyIndex++;
        MapManager.occupiedTiles[x, y] = 2;
        hasSpawned = true;
    }

    public bool SearchEnemyArray(int x, int y) {
        for (int i = 0; i < enemyIndex; i++) {
            if (enemyArray[i] != null)
            {
                if ((enemyArray[i].transform.position.x == x) && (enemyArray[i].transform.position.y == y))
                {
                    enemySearched = enemyArray[i];
                    //Debug.Log("Enemy detected in spawn spot");
                    return false;
                }
            }
        }
        //Debug.Log("No enemy detected in spawn spot");
        return true;
    }

    public GameObject lastEnemySearched()
    {
        return enemySearched;
    }




    // Update is called once per frame
    void Update () {
	
	}
}
