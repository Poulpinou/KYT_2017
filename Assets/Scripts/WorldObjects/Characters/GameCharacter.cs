using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class GameCharacter : WorldObject
{
    private bool canAct;
    protected bool isMoving;
    protected Vector2 origin;
    protected Vector2 destination;
    protected float trajectAmount;
    public float speed;
    public char orientation;
    

    protected virtual void performAction()
    {

    }

    public void moveTo(Vector2 destination)
    {    
        this.destination = destination;
        origin = transform.position;
        GetComponent<SpriteRenderer>().flipX = (destination.x > origin.x && orientation == 'l') || (destination.x < origin.x && orientation == 'r');
        trajectAmount = 0;
        isMoving = true;
    }

    private void move()
    {
        trajectAmount += Time.deltaTime * speed;
        if(trajectAmount >= 1)
        {
            transform.position = new Vector3(destination.x, destination.y, -5);
            isMoving = false;
        }
        else
        {
            transform.position = Vector2.Lerp(origin, destination, trajectAmount);
        }
        
    }

    private bool iddleOn;
    private void iddle()
    {

    }


    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        isMoving = false;
        iddleOn = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (canAct)
            performAction();
        if (isMoving)
        {
            move();
        }
        else
        {
            if (iddleOn)
                iddle();
        }
           
        

    }
}
