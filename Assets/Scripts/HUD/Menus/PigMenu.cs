using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMenu : MonoBehaviour {
    public Pig pig;

    public void enable(int menuKey)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        //GetComponent<Collider2D>().enabled = true;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
           button.GetComponent<SpriteRenderer>().enabled = button.tag == "Menu_" + menuKey;
           button.GetComponent<Collider2D>().enabled = button.tag == "Menu_" + menuKey;
        }
        
    }

    public void close()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<Collider2D>().enabled = true;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.GetComponent<SpriteRenderer>().enabled = false;
            button.GetComponent<Collider2D>().enabled = false;
        }
    }

	// Use this for initialization
	void Awake () {
        pig = this.GetComponentInParent<Pig>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
