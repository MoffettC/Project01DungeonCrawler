using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Vector3 pos;
    private int moveSpeed = 6;
    private MapManager MapManager;
    private CharacterManager charManager;
    private EnemyManager enemyManager;
    private ItemManager itemManager;

    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        MapManager = FindObjectOfType<MapManager>();
        itemManager = FindObjectOfType<ItemManager>();
        pos = new Vector3(charManager.spawnX, charManager.spawnY, 0);
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position == pos)
        {
            //Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y) + 1;
            int originalPosX = (int)(pos.x);
            int originalPosY = (int)(pos.y);
            //Debug.Log(playerPos);
            //Debug.Log("wallTiles: " + playerPosX + (playerPosY + 1) + " " + TileMap.wallTiles[playerPosX, playerPosY + 1]);
            if ((MapManager.wallTiles[playerPosX, playerPosY] == 0) && (MapManager.occupiedTiles[playerPosX, playerPosY] == 0))
            {
                //Debug.Log("OccupiedTile Occupied: " + playerPosX + (playerPosY + 1));
                //Debug.Log("OccupiedTile Open: " + playerPosX + playerPosY);
                MapManager.occupiedTiles[playerPosX, playerPosY] = 1;
                MapManager.occupiedTiles[originalPosX, originalPosY] = 0;
                pos += Vector3.up;
            } else if (enemyManager.SearchEnemyArray(playerPosX, playerPosY) == false)
            {
                Debug.Log("Player Attack Detected");
                GameObject enemy = enemyManager.lastEnemySearched();
                playerWeaponDamage(enemy);
            } else if (MapManager.occupiedTiles[playerPosX, playerPosY] == 3) {
                //Check to see if gO has a script that inherits from item, then invokes IUseItem interface
                IUseItem itemTest = itemManager.itemsAtLocation[playerPosX, playerPosY].GetComponent<IUseItem>() as IUseItem;
                if (itemTest != null) {
                    itemTest.useItem();
                    MapManager.occupiedTiles[originalPosX, originalPosY] = 0;
                    Destroy(itemManager.itemsAtLocation[playerPosX, playerPosY]);
                    pos += Vector3.up;
                    MapManager.occupiedTiles[playerPosX, playerPosY] = 1;
                }
            }
            else if (MapManager.occupiedTiles[playerPosX, playerPosY] == 10)
            {
                Debug.Log("Player Victory!");
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                MapManager.occupiedTiles[originalPosX, originalPosY] = 1;
                pos += Vector3.up;
            }
            else
            {
                Debug.Log("Cant Walk Up!");
            }

            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position == pos)
        {
            //Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if ((MapManager.wallTiles[playerPosX - 1, playerPosY] == 0) && (enemyManager.SearchEnemyArray(playerPosX - 1, playerPosY))
                 && (MapManager.occupiedTiles[playerPosX - 1, playerPosY] == 0))
            {
                //Debug.Log("OccupiedTile Occupied: " + (playerPosX - 1) + playerPosY);
                //Debug.Log("OccupiedTile Open: " + playerPosX + playerPosY);
                MapManager.occupiedTiles[playerPosX - 1, playerPosY] = 1;
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                pos += Vector3.left;
            }
            else if (enemyManager.SearchEnemyArray(playerPosX - 1, playerPosY) == false)
            {
                Debug.Log("Player Attack Detected");
                GameObject enemy = enemyManager.lastEnemySearched();
                playerWeaponDamage(enemy);
            }
            else if (MapManager.occupiedTiles[playerPosX - 1, playerPosY] == 3)
            {
                //Check to see if gO has a script that inherits from item, then invokes IUseItem interface
                IUseItem itemTest = itemManager.itemsAtLocation[playerPosX - 1, playerPosY].GetComponent<IUseItem>() as IUseItem;
                if (itemTest != null)
                {
                    itemTest.useItem();
                    MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                    Destroy(itemManager.itemsAtLocation[playerPosX - 1, playerPosY]);
                    pos += Vector3.left;
                    MapManager.occupiedTiles[playerPosX - 1, playerPosY] = 1;
                }
            }
            else if (MapManager.occupiedTiles[playerPosX - 1, playerPosY] == 10)
            {
                Debug.Log("Player Victory!");
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                MapManager.occupiedTiles[playerPosX - 1, playerPosY] = 0;
                pos += Vector3.left;
            }
            else
            {
                Debug.Log("Cant Walk Left!");
            }

            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position == pos)
        {
            //Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if ((MapManager.wallTiles[playerPosX, playerPosY - 1] == 0) && (enemyManager.SearchEnemyArray(playerPosX, playerPosY - 1))
                 && (MapManager.occupiedTiles[playerPosX, playerPosY - 1] == 0))
            {
                MapManager.occupiedTiles[playerPosX, playerPosY - 1] = 1;
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                //Debug.Log("OccupiedTile Occupied: " + playerPosX + (playerPosY - 1));
                //Debug.Log("OccupiedTile Open: " + playerPosX + playerPosY);
                pos += Vector3.down;
            }
            else if (enemyManager.SearchEnemyArray(playerPosX, playerPosY - 1) == false)
            {
                Debug.Log("Player Attack Detected");
                GameObject enemy = enemyManager.lastEnemySearched();
                playerWeaponDamage(enemy);
            }
            else if (MapManager.occupiedTiles[playerPosX, playerPosY - 1] == 3)
            {
                //Check to see if gO has a script that inherits from item, then invokes IUseItem interface
                IUseItem itemTest = itemManager.itemsAtLocation[playerPosX, playerPosY - 1].GetComponent<IUseItem>() as IUseItem;
                if (itemTest != null)
                {
                    itemTest.useItem();
                    MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                    Destroy(itemManager.itemsAtLocation[playerPosX, playerPosY - 1]);
                    pos += Vector3.down;
                    MapManager.occupiedTiles[playerPosX, playerPosY - 1] = 1;
                }
            }
            else if (MapManager.occupiedTiles[playerPosX, playerPosY - 1] == 10)
            {
                Debug.Log("Player Victory!");
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                MapManager.occupiedTiles[playerPosX, playerPosY - 1] = 0;
                pos += Vector3.down;
            }
            else
            {
                Debug.Log("Cant Walk Down!");
            }
            // transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position == pos)
        {
           // Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if ((MapManager.wallTiles[playerPosX + 1, playerPosY] == 0) && (enemyManager.SearchEnemyArray(playerPosX + 1, playerPosY))
                 && (MapManager.occupiedTiles[playerPosX + 1, playerPosY] == 0))
            {
                MapManager.occupiedTiles[playerPosX + 1, playerPosY] = 1;
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                //Debug.Log("OccupiedTile Occupied: " + (playerPosX + 1) + playerPosY);
                //Debug.Log("OccupiedTile Open: " + playerPosX + playerPosY);
                pos += Vector3.right;
            }
            else if (enemyManager.SearchEnemyArray(playerPosX + 1, playerPosY) == false)
            {
                Debug.Log("Player Attack Detected");
                GameObject enemy = enemyManager.lastEnemySearched();
                playerWeaponDamage(enemy);
            }
            else if (MapManager.occupiedTiles[playerPosX + 1, playerPosY] == 3)
            {
                //Check to see if gO has a script that inherits from item, then invokes IUseItem interface
                IUseItem itemTest = itemManager.itemsAtLocation[playerPosX + 1, playerPosY].GetComponent<IUseItem>() as IUseItem;
                if (itemTest != null)
                {
                    itemTest.useItem();
                    MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                    Destroy(itemManager.itemsAtLocation[playerPosX + 1, playerPosY]);
                    pos += Vector3.right;
                    MapManager.occupiedTiles[playerPosX + 1, playerPosY] = 1;
                }
            }
            else if (MapManager.occupiedTiles[playerPosX + 1, playerPosY] == 10)
            {
                Debug.Log("Player Victory!");
                MapManager.occupiedTiles[playerPosX, playerPosY] = 0;
                MapManager.occupiedTiles[playerPosX + 1, playerPosY] = 0;
                pos += Vector3.right;
            }
            else
            {
                Debug.Log("Cant Walk Right!");
            }
            // transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        //Debug.Log(pos);
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * moveSpeed);
    }

    public void playerWeaponDamage(GameObject enemy)
    {
        double weaponDamage = 20f;
        enemy.GetComponent<Health>().Damage(weaponDamage);
    }



}


