using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingButton : Button {

    public BuildingElement target;

    public override void click()
    {
        base.click();
        gameManager.setElementToBuild(target);
        gameManager.changeMode(Mode.Build);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
