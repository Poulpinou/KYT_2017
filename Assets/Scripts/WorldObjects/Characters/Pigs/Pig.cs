using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class Pig : GameCharacter {

    public Straw holdStraw;
    public BuildingElement mission;
    public string actualAction;
    public float iddleZoneX; public float iddleZoneY;

    public override void click()
    {
        base.click();
        if(gameManager.getCurrentMode() == Mode.Play)
        {
            gameManager.setSelectedElement(this);
            enableMenu();
        }
    }

    protected override void performAction()
    {
        if (actualAction != null)
        {
            switch (this.actualAction)
            {
                case "convoy":
                    {
                        break;
                    }
                case "repair":
                    {
                        break;
                    }
                case "recycle":
                    {
                        break;
                    }
                case "hold":
                    {
                        break;
                    }
                default:
                    {
                        actualAction = null;
                        break;
                    }

            }
        }
        
    }

    private void enableMenu()
    {

    }

    // Use this for initialization
    void Start () {
        moveTo(new Vector2(iddleZoneX, iddleZoneY));
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
