using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bloup;

public class UserInput : MonoBehaviour
{
    private GameManager gameManager;

    private void MouseActivity()
    {
        if (Input.GetMouseButtonDown(0)) LeftMouseClick();
        else if (Input.GetMouseButtonDown(1)) RightMouseClick();
        MouseHover();
    }

    private void LeftMouseClick()
    {

        GameObject hitObject = FindHitObject(Input.mousePosition);
        Vector2 hitPoint = FindHitPoint(Input.mousePosition);
        
        if (gameManager.getCurrentMode() == Mode.Place)
        {
            //gameManager.changeMode(Mode.Play);
            gameManager.getElementToBuild().build();
            gameManager.changeMode(Mode.Play);
        }
        else
        {
            if (hitObject)
            {
                hitObject.GetComponent<WorldObject>().click();
            }
        }

    }

    private void RightMouseClick()
    {
        GameObject hitObject = FindHitObject(Input.mousePosition);
        Vector2 hitPoint = FindHitPoint(Input.mousePosition);
        if (gameManager.getCurrentMode() == Mode.Play && hitObject)
        {
            Destroy(hitObject);
        }
    }

    private void MouseHover()
    {
        if(gameManager.getCurrentMode() != Mode.Place)
        {
            GameObject hitObject = FindHitObject(Input.mousePosition);
            Vector2 hitPoint = FindHitPoint(Input.mousePosition);
            if (hitObject && hitObject.name != "background")
            {
                hitObject.GetComponent<WorldObject>().mouseOver();
            }
        }
        
    }

    public static GameObject FindHitObject(Vector2 origin)
    {
        //Ray ray = Camera.main.ScreenPointToRay(origin);
        //RaycastHit hit;
        //RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, -Vector2.up);
        //if (Physics.Raycast(ray, out hit)) return hit.collider.gameObject;
        //if (hit) return hit.collider.gameObject;
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if(hit && hit.collider) return hit.collider.gameObject;
        return null;
    }

    public static Vector2 FindHitPoint(Vector2 origin)
    {
        //Ray ray = Camera.main.ScreenPointToRay(origin);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit)) return hit.point;
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if(hit) return hit.point;
        return new Vector2(0, 0);
    }

    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            MouseActivity();
        if (gameManager.getCurrentMode() == Mode.Place && !gameManager.getElementToBuild().isBuilt())
            gameManager.getElementToBuild().FollowCursor(FindHitPoint(Input.mousePosition));
    }
}
