using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class GameManager : MonoBehaviour {
    private WorldObject selectedElement;
    private Mode mode;
    public Player player;

    public Mode getCurrentMode()
    {
        return mode;
    }

    public void changeMode(Mode mode)
    {
        this.mode = mode;
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



    // Use this for initialization
    void Start () {
        mode = Mode.Play;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
