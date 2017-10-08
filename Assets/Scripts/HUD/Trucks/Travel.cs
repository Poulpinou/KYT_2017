using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour {
    private LoadTravelBar bar;
    public Pig pig;
    public BuildingElement mission;
    private Slot slot;

    private float progress;
    private bool inProgress;
    public float speed;

    public void start(Slot slot)
    {
        this.slot = slot;
        bar.initialize();
        progress = 0;
        inProgress = true;
    }

    private void drive()
    {
        progress += (Time.deltaTime * speed) / 100;
        if (progress >= 1)
        {
            stop();
        }
        else
        {
            bar.makeProgress(progress);
        }
    }

    private void stop()
    {  
        pig.actualAction = "come_back";
        ActionBar actionBar = Camera.main.GetComponent<GameManager>().actionBar;
        int objectif = mission.getAmountHarvested();
  
        for(int i = 1; i <= objectif; i++)
        {
            actionBar.addToStock(mission);
        }
        actionBar.reloadActions();
        Destroy(this.gameObject);
    }
    
        

	// Use this for initialization
	void Awake () {
        bar = GetComponentInChildren<LoadTravelBar>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inProgress)
            drive();
	}
}
