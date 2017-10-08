using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    protected GameManager gameManager;
    protected bool isHeightReached = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<BuildingElement>())
        {
            gameManager.calculatePoints();
            isHeightReached = true;
        }

    }

    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isVictory()) Destroy(gameObject);
    }
}
