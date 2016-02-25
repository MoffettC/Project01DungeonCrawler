using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    Vector3 pos;

    public int moveSpeed = 4;
    private TileMap tileMap;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        tileMap = GameObject.FindObjectOfType<TileMap>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.W) && transform.position == pos) {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x + 0.5);
            int playerPosY = (int)(pos.y + 0.5);
            if (tileMap.Walkable(playerPosX, playerPosY + 1)) {
                pos += Vector3.up;
            } else {
                Debug.Log("Cant Walk Up!");
            }

            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position == pos) {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x + 0.5);
            int playerPosY = (int)(pos.y + 0.5);
            if (tileMap.Walkable(playerPosX - 1, playerPosY)) {
                pos += Vector3.left;
            } else {
                Debug.Log("Cant Walk Left!");
            }

            // transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position == pos) {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x + 0.5);
            int playerPosY = (int)(pos.y + 0.5);
            if (tileMap.Walkable(playerPosX, playerPosY - 1)) {
                pos += Vector3.down;
            } else {
                Debug.Log("Cant Walk Down!");
            }
            // transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position == pos) {
            Vector3 playerPos = pos;
            int playerPosX = (int)(pos.x + 0.5);
            int playerPosY = (int)(pos.y + 0.5);
            if (tileMap.Walkable(playerPosX + 1, playerPosY)) {
                pos += Vector3.right;
            } else {
                Debug.Log("Cant Walk Right!");
            }
            // transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * moveSpeed);
    }
}
