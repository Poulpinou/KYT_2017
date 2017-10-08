using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {

    private bool isPaused = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        if (isPaused)
            Time.timeScale = 0f;

        else
            Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        if(isPaused)
        {

            if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer"))
            {
                isPaused = false;
            }

            if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Quitter"))
            {
                // Application.Quit()
                // Application.LoadLevel("Menu Principal");
            }

        }
    }
}
