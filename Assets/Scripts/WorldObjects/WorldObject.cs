﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour {
    protected GameManager gameManager;

    public virtual void click()
    {

    }

    public virtual void mouseOver()
    {

    }

    // Use this for initialization
    void Awake () {
        gameManager = Camera.main.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
