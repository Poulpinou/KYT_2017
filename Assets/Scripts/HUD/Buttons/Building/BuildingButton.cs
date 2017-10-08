using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class BuildingButton : Button {

    public BuildingElement target;
    public int listIndex;
    public TextMesh numberText;

    public override void click()
    {
        base.click();
        gameManager.actionBar.removeFromList(this);
        gameManager.setElementToBuild(target);
        gameManager.changeMode(Mode.Place);
        BuildingElement created = Instantiate(gameManager.getElementToBuild(), Input.mousePosition, Quaternion.identity);
        created.transform.parent = gameManager.player.transform;
        created.setValue(target.getValue());
        created.GetComponent<Rigidbody2D>().simulated = false;
        gameManager.setElementToBuild(created);
    }

    public void mutate(BuildingElement element)
    {
        
        this.GetComponent<SpriteRenderer>().sprite = element.GetComponent<SpriteRenderer>().sprite;
        element.setValue(Random.Range(1, 20));
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        this.target = element;
        numberText.text = element.getValue() + "";
    }

    // Use this for initialization
    protected override void Awake () {
        base.Awake();
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
