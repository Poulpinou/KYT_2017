using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class Pig : GameCharacter {

    public Straw holdStraw;
    public BuildingElement mission;
    public string actualAction;
    public string subaction;
    public float iddleZoneX; public float iddleZoneY;

    public override void click()
    {
        base.click();
        if(gameManager.getCurrentMode() == Mode.Play /*&& (actualAction != null || actualAction == "" || actualAction == "working")*/)
        {
            gameManager.setSelectedPig(this);
            enableMenu();
        }
    }

    protected override void performAction()
    {
        //Debug.Log(actualAction + "/" + subaction);
        if (actualAction != null || actualAction == "working")
        {
            switch (this.actualAction)
            {
                case "convoy":
                    {
                        if (subaction == null)
                        {
                            gameManager.changeMode(Mode.ConvoySelect);
                            subaction = "select_convoy";
                            enableSelectTypeMenu();
                        }
                        if (subaction == "go_to")
                        {
                            moveTo(new Vector2(12, 0));
                            subaction = "moving";
                        }
                        if (subaction == "moving")
                        {
                            if (!isMoving)
                            {
                                Slot slot = gameManager.getFirstAvailableSlot();
                                slot.generateTravel(this, mission);
                                subaction = "driving";
                            }
                        }
                        break;
                    }
                case "repair":
                    {
                        break;
                    }
                case "recycle":
                    {
                        if (subaction == null)
                        {
                            gameManager.changeMode(Mode.RecycleSelect);
                            subaction = "select_recycle";
                        }
                        if (subaction == "go_to")
                        {
                            moveTo(mission.transform.position);
                            subaction = "moving";

                        }
                        if (subaction == "moving")
                        {
                            if (!isMoving)
                            {
                                mission.recycle();
                                //Ajouter du temps d'attente
                                actualAction = null;
                                subaction = null;
                                mission = null;
                                moveTo(new Vector2(iddleZoneX, iddleZoneY));
                            }
                        }
                        break;
                    }
                case "hold":
                    {
                        if(subaction == null)
                        {
                            gameManager.changeMode(Mode.HoldSelect);
                            subaction = "select_hold";
                        }
                        if(subaction == "go_to")
                        {
                            moveTo(holdStraw.transform.position);
                            subaction = "moving";

                        }
                        if(subaction == "moving")
                        {
                            if (!isMoving)
                            {
                                actualAction = "working";
                                holdStraw.protect(true);
                                subaction = null;
                            }
                        }
                        break;
                    }
                case "working":
                    {
                        break;
                    }
                default:
                    {
                        actualAction = null;
                        subaction = null;
                        moveTo(new Vector2(iddleZoneX, iddleZoneY));
                        break;
                    }

            }
        }
        
    }

    private void enableMenu()
    {
        GetComponentInChildren<PigMenu>().enable(1);
    }

    private void enableSelectTypeMenu()
    {
        GetComponentInChildren<PigMenu>().enable(2);

    }

    // Use this for initialization
    protected override void Awake () {
        base.Awake();
        //Debug.Log(gameManager.name);
        moveTo(new Vector2(iddleZoneX, iddleZoneY));
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        performAction();
    }

    private void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        subaction = null;
        actualAction = null;
    }
}
