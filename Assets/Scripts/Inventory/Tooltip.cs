using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject tooltip;
    private string[] rarityValues = {"EEEEEE", "73ED47", "00BFFF", "B960FC", "FCA32D"};

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        Debug.Log(tooltip + " was Found");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<size=16><b>" + item.Title + "</b></size>\n\n" + item.Description + "\n\nPower: " + item.Power + ""; 
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
