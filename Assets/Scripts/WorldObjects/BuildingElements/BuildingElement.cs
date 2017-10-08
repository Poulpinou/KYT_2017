using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingElement : WorldObject {
    protected bool builded;
    int value ;

    public int getAmountHarvested()
    {
        string type = this.GetType().Name;
        if (type == "Brick") return 1;
        if (type == "Wood") return 2;
        if (type == "Straw") return 3;
        return 0;
    }

    public int getValue()
    {
        return value;
    }

    public void setValue(int value)
    {
        this.value = value;
    }

    public bool isInRange()
    {
        /*int width = Screen.width;
        int quartWidth = width / 100 * 25;
        Debug.Log("25% : " + quartWidth);
        int troisquartWidth = width / 100 * 75;
        Debug.Log("75% : " + troisquartWidth);*/
        return transform.position.x >= -4 && transform.position.x <= 4 && builded;
    }

    public void rotate()
    {
        Debug.Log("Rotate");
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90));
    }

    public void recycle()
    {
        ActionBar actionBar = Camera.main.GetComponentInChildren<ActionBar>();
        actionBar.addToStock(this);
        actionBar.reloadActions();
        Destroy(this.gameObject);
    }

    public bool isBuilt()
    {
        return builded;
    }

    public void FollowCursor(Vector2 mousePosition)
    {
        transform.position = mousePosition;
        GetComponentInChildren<TextMesh>().text = value.ToString();
    }

    public void build()
    {
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponentInChildren<TextMesh>().text = value.ToString();
        builded = true;
        
    }
    // Use this for initialization
    protected override void Awake () {
        base.Awake();
        builded = false;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        if (GetComponentInChildren<TextMesh>().transform.rotation != Quaternion.identity) GetComponentInChildren<TextMesh>().transform.rotation = Quaternion.identity;


    }
}
