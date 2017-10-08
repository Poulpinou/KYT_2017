using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : BuildingElement {
    private bool damaged;
    public GameObject fracture;
    public GameObject[] parts = new GameObject[2];
    private float requiem;

    public bool isDamaged()
    {
        return damaged;
    }

    public void damage()
    {
        damaged = true;
        fracture.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void repair()
    {
        damaged = false;
        fracture.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void breakPlank()
    {
        
        foreach(GameObject part in parts)
        {
            part.GetComponent<SpriteRenderer>().enabled = true;
            part.GetComponent<Collider2D>().enabled = true;
        }
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        fracture.GetComponent<SpriteRenderer>().enabled = false;
        requiem = 0;

    }

    public void die()
    {
        //Debug.Log(requiem);
        requiem += Time.deltaTime;
        if (requiem > 10)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(requiem >= 0)
            die();
    }

    private void Awake()
    {
        damaged = false;
        requiem = -1;
    }
}
