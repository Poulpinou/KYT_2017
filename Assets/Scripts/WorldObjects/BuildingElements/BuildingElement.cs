using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingElement : WorldObject {
    protected bool builded;
    int value;

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
        return transform.position.x >= -10 && transform.position.x <= 10;
    }

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
        value = Random.Range(1, 20);
        GetComponentInChildren<TextMesh>().text = value.ToString();
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        
        if (GetComponentInChildren<TextMesh>().transform.rotation != Quaternion.identity) GetComponentInChildren<TextMesh>().transform.rotation = Quaternion.identity;

    }
}
