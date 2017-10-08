using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : Button
{
    public string action;
    private Pig pig;
    private PigMenu menu;

    public override void click()
    {
        base.click();
        pig.actualAction = action;
        //Debug.Log(pig.actualAction);
        if(action != "convey")
            menu.close();
    }

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        menu = this.GetComponentInParent<PigMenu>();
        pig = menu.pig;
    }
}
	
