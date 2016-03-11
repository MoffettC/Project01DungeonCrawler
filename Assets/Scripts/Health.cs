using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public GameObject healthBar;

    private MapManager mapManager;
    private double totalHealth = 100f;
    private double currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = totalHealth;
        mapManager = FindObjectOfType<MapManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(double damageTaken)
    {
        currentHealth -= damageTaken;
        double calcHealth = currentHealth / totalHealth;
        SetHealthBar(calcHealth);
        if (calcHealth <= 0)
        {
            MapManager.occupiedTiles[(int)transform.position.x, (int)transform.position.y] = 0;
            Destroy(gameObject);
        }
    }

    public void SetHealthBar(double myHealth)
    {
       healthBar.transform.localScale = new Vector3(Mathf.Clamp((float)myHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
