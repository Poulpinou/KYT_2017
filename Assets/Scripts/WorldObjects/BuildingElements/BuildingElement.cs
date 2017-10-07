using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingElement : WorldObject {

    int value;

	// Use this for initialization
	void Start () {
        
	}

    void Awake()
    {
        value = Random.Range(1, 20);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public int getValue()
    {
        return value;
    }

    public bool isInRange()
    {
        /*int width = Screen.width;
        int quartWidth = width / 100 * 25;
        Debug.Log("25% : " + quartWidth);
        int troisquartWidth = width / 100 * 75;
        Debug.Log("75% : " + troisquartWidth);*/
        return transform.position.x >= -10 && transform.position.x  <= 10;
    }
}
