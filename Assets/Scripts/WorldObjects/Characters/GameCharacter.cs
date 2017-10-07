using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class GameCharacter : WorldObject
{
    private bool canAct;
   

    protected virtual void performAction()
    {

    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (canAct)
            performAction();

    }
}
