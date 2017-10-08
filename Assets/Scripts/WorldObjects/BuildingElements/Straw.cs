using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : BuildingElement {
    private bool guarded;

    public bool isProtected()
    {
        return guarded;
    }

    public void protect(bool isProtected)
    {
        Debug.Log("protected");
        guarded = isProtected;
    }
    

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
