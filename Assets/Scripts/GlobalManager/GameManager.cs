using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class GameManager : MonoBehaviour {
    private WorldObject selectedElement;
    private Mode mode;
    public Player player;
    public int points = 0;
    public int objective = 42;

    public Mode getCurrentMode()
    {
        return mode;
    }

    public void changeMode(Mode mode)
    {
        this.mode = mode;
    }

    public void setSelectedElement(WorldObject element)
    {
        selectedElement = element;
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
