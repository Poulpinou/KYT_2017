using System.Collections;
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
    protected virtual void Awake () {
        gameManager = Camera.main.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}
}
