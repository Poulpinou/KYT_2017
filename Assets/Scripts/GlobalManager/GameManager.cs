using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class GameManager : MonoBehaviour {
    private Pig selectedPig;
    private Mode mode;
    public ActionBar actionBar;
    public Player player;
    public int points = 0;
    public int objective = 42;
    public Slot[] slots = new Slot[3];

    public Slot getFirstAvailableSlot()
    {
        foreach(Slot slot in this.slots)
        {
            Debug.Log("Slot: "+ slot.available());
            if (slot.available())
                return slot;
        }
        return null;
    }

    public Mode getCurrentMode()
    {
        return mode;
    }

    public void changeMode(Mode mode)
    {
        this.mode = mode;
    }

    public void setSelectedPig(Pig pig)
    {
        selectedPig = pig;
    }

    public Pig getSelectedPig()
    {
        return selectedPig;
    }

    //Building
    private BuildingElement selectedConstruction;

    public BuildingElement getElementToBuild()
    {
        return selectedConstruction;
    }

    public void setElementToBuild(BuildingElement elementToBuild)
    {
        selectedConstruction = elementToBuild;
    }

    public void calculatePoints()
    {
        points = 0;
        foreach (BuildingElement child in player.transform.GetComponentsInChildren<BuildingElement>())
        {
            if (child.isInRange()) points += child.getValue();
        }

    }

    public bool isVictory()
    {
        return points == objective;
    }



    // Use this for initialization
    void Start () {
        mode = Mode.Play;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
