using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
    public Travel travelPrefab;
    private Travel travel;

    public bool available()
    {
        return travel == null;
        //return (bool)travel;
    }

    public void generateTravel(Pig pig, BuildingElement mission)
    {
        travel = Instantiate(travelPrefab, this.transform.position, Quaternion.identity);
        travel.pig = pig;
        travel.mission = mission;
        travel.start(this);

    }

	// Use this for initialization
	void Start () {
        travel = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
