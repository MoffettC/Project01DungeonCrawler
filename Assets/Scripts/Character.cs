using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Vector3 pos;
    private int moveSpeed = 6;
    private MapManager tileMap;
    private CharacterManager charManager;

    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();
        pos = new Vector3(charManager.spawnX, charManager.spawnY, 0);
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position == pos)
        {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            //Debug.Log(playerPos);
            //Debug.Log("wallTiles: " + playerPosX + (playerPosY + 1) + " " + TileMap.wallTiles[playerPosX, playerPosY + 1]);
            if (MapManager.wallTiles[playerPosX, playerPosY + 1] == 0)
            {
                pos += Vector3.up;
                Debug.Log("Moving Up!");
            }
            else
            {
                Debug.Log("Cant Walk Up!");
            }

            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position == pos)
        {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if (MapManager.wallTiles[playerPosX - 1, playerPosY] == 0)
            {
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
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if (MapManager.wallTiles[playerPosX, playerPosY - 1] == 0)
            {
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
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x);
            int playerPosY = (int)(pos.y);
            if (MapManager.wallTiles[playerPosX + 1, playerPosY] == 0)
            {
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
}


