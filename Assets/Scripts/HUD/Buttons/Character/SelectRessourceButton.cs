using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRessourceButton : Button {
    public PigMenu menu;
    public BuildingElement toHarvest;
    private Pig pig;

    public override void click()
    {
        base.click();
        //Debug.Log(pig.actualAction);
        if(pig.actualAction == "convoy")
        {
           // Debug.Log("Passe");
            pig.subaction = "go_to";
            pig.mission = toHarvest;
        }
        else
        {
            pig.actualAction = null;
        }
        menu.close();
    }

    // Use this for initialization
     void Start()
    {
        menu = this.GetComponentInParent<PigMenu>();
        pig = menu.pig;
    }
}
