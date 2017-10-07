using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    protected GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.collider.gameObject;
        if (obj.GetComponent<BuildingElement>()) gameManager.calculatePoints();
    }

    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}