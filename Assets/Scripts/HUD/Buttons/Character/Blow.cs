using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour {

    private float scaleAmount;
    private char direction;
    public float turbulences;
	
	// Update is called once per frame
	void Update () {
		if(scaleAmount > 1.5f)
        {
            direction = 'd';
        }
        else if(scaleAmount < 1)
        {
            direction = 'u';
        }
    
            if(direction == 'd')
            {
                scaleAmount -= Time.deltaTime * turbulences;
            }
            else
            {
                scaleAmount += Time.deltaTime * turbulences;
            }
        
        transform.localScale = new Vector2(scaleAmount, scaleAmount);
	}

    private void Start()
    {
        scaleAmount = 1;
        direction = 'd';
    }
}
