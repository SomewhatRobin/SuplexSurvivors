using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : MonoBehaviour
{
    public GameObject PauseMenu;

    public void OnClick()
    {
        GameManager.isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
