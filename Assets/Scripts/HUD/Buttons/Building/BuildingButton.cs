using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingButton : Button {

    public BuildingElement target;

    public override void click()
    {
        base.click();
        gameManager.setElementToBuild(target);
        gameManager.changeMode(Mode.Place);
        BuildingElement created = Instantiate(gameManager.getElementToBuild(), Input.mousePosition, Quaternion.identity);
        created.transform.parent = gameManager.player.transform;
        created.GetComponent<Rigidbody2D>().simulated = false;
        gameManager.setElementToBuild(created);
    }

    public void mutate(BuildingElement element)
    {
        this.target = element;
        this.GetComponent<SpriteRenderer>().sprite = element.GetComponent<SpriteRenderer>().sprite;
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
