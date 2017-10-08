using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTravelBar : MonoBehaviour {
    public void initialize()
    {
        transform.localScale = new Vector3(0, 1, 1);
    }

    public void makeProgress(float newState)
    {
        transform.localScale = new Vector3(newState, 1, 1);
    }

	
}
