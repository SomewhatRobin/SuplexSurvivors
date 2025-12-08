using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : MonoBehaviour
{
    public GameObject PauseMenu;

    public KeyCode crGrab, crGrab2;

    public void OnClick()
    {
        GameManager.isPaused = false;
        if (Input.GetKeyDown(crGrab) || Input.GetKey(crGrab) || Input.GetKeyDown(crGrab2) || Input.GetKey(crGrab2))
        {
            //Lets the GM know a controller was used to exit the menu.
            GameManager.fromPause = true;
        }

        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
