using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour {
    //Prefabs
    public BuildingButton buildingButtonPrefab;
    private List<BuildingButton> stock = new List<BuildingButton>();
    private ActionBarStart start;

    public void addToStock(BuildingElement element)
    {
        BuildingButton button = Instantiate(buildingButtonPrefab, transform.position, Quaternion.identity);
        button.mutate(element);
        //Destroy(element.gameObject);
        button.transform.parent = this.transform;
        
        stock.Add(button);
        //reloadActions();
    }

    public void removeFromList(BuildingButton element)
    {
        //Debug.Log(stock);
        stock.RemoveAt(element.listIndex);
        element.GetComponent<SpriteRenderer>().enabled = false;
        element.GetComponent<Collider2D>().enabled = false;
        Destroy(element.gameObject);
        reloadActions();
    }
    

    public void reloadActions()
    {
        Debug.Log(stock);
        int i = 0;
        foreach(BuildingButton button in stock)
        {
            button.transform.localPosition = new Vector3(start.transform.localPosition.x + i, 0, -1);
            button.listIndex = stock.IndexOf(button);
            //button.transform.localScale = new Vector2(1 / 4, 1 / 4);
            //button.GetComponent<Collider2D>().transform.localScale = new Vector2(2, 2);
            i++;
            if (i > 18)
                break;
        }
    }

	// Use this for initialization
	void Start () {
        start = GetComponentInChildren<ActionBarStart>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
