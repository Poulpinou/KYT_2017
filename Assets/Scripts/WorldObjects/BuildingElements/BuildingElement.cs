using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingElement : WorldObject {
    protected bool builded;

    public bool isBuilt()
    {
        return builded;
    }

    public void FollowCursor(Vector2 mousePosition)
    {
        transform.position = mousePosition;
    }

    public void build()
    {
        GetComponent<Rigidbody2D>().simulated = true;
        builded = true;
        
    }
    // Use this for initialization
    void Awake () {
        builded = false;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        

    }
}
