using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : WorldObject {

    public override void click()
    {
        base.click();

    }

    public override void mouseOver()
    {
        base.mouseOver();
        Debug.Log("passe");
        this.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
