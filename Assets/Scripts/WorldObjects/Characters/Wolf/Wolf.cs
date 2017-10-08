using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : GameCharacter {
    private Vector2 hiddenPosition;
    private string step;
    private string subaction;
    private float waitingTime;
    private float waited;
    private int[] weightsInOrder = { 30, 0, 10, 5, 0 };
    private int phase;
    private SpriteRenderer sprite;
    public Sprite[] sprites = new Sprite[3];
    public Blow blow;

    private void wolfCycle()
    {
        switch (step)
        {
            case "waiting":
                {
                    if (waited > waitingTime)
                    {
                        moveTo(new Vector2(-7, 1.5f));
                        phase = 2;
                        step = "comming";
                    }
                    else
                    {
                        waited += Time.deltaTime;
                    }
                    break;
                }
            case "comming":
                {
                    if (!isMoving)
                    {
                        phase = 3;
                        step = "taunt";
                        waited = 0;
                        calculateWaitingTime();
                    }
                    break;
                }
            case "taunt":
                {
                    if (waited > waitingTime)
                    {
                        phase = 4;
                        step = "attack";
                        waited = 0;
                        sprite.sprite = sprites[1];
                    }
                    else
                    {
                        waited += Time.deltaTime;
                    }
                    break;
                }
            case "attack":
                {
                    if (waited > 1.5f && phase == 4)
                    {                 
                        sprite.sprite = sprites[1];
                        phase = 5;
                        waited = 0;
                    }
                    else if (waited > 1.5f && phase == 5)
                    {
                        sprite.sprite = sprites[2];
                        blow.GetComponent<SpriteRenderer>().enabled = true;
                        phase = 6;
                        waited = 0;
                    }
                    else if (waited > 3 && phase == 6)
                    {
                        sprite.sprite = sprites[0];
                        blow.GetComponent<SpriteRenderer>().enabled = false;
                        blowOnBuilding();
                        phase = 5;
                        step = "return";
                        waited = 0;
                        moveTo(hiddenPosition);
                    }
                    else
                    {
                        waited += Time.deltaTime;
                    }
                    break;
                }
            case "return":
                {
                    if (!isMoving)
                    {
                        phase = 0;
                        step = "waiting";
                        waited = 0;
                        calculateWaitingTime();
                    }
                    break;
                }
        }
    }

    private void calculateWaitingTime()
    {
        waitingTime = (weightsInOrder[phase] * (Random.value + 0.5f)) / gameManager.level;
    }

    public void blowOnBuilding()
    {
        Straw[] straws = gameManager.player.GetComponentsInChildren<Straw>();
        foreach(Straw straw in straws)
        {
            if (!straw.isProtected())
            {
                straw.GetComponent<SpriteRenderer>().enabled = false;
                straw.GetComponent<Collider2D>().enabled = false;
                Destroy(straw.gameObject);
            }
        }

        Wood[] wood = gameManager.player.GetComponentsInChildren<Wood>();
        foreach (Wood plank in wood)
        {

            if (plank.isDamaged())
            {
                plank.breakPlank();
            }
            else
            {
                plank.damage();
            }
        }
    }


    protected override void Update()
    {
        base.Update();
        wolfCycle();
    }

    // Use this for initialization
    void Start () {
        hiddenPosition = transform.position;
        step = "waiting";
        phase = 0;
        waited = 0;
        calculateWaitingTime();
        sprite = GetComponent<SpriteRenderer>();
        blow.GetComponent<SpriteRenderer>().enabled = false;

    }
	
}
