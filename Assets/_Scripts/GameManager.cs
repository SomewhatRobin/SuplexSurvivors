using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static int HP = 5; //Short for "Hand Points"
    public static int startHP = 5;
    public static int staMana = 2;
    public static bool _gameOver = false;
    public static bool isPaused = false;
    public static bool fromPause = false;
    public static float combineValue = 0.00f;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        StartGame();
        fromPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                isPaused = true;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }


    public static void StartGame()
    {
        Score = 0;
        HP = startHP;
        staMana = 2;
        _gameOver = false;
        isPaused = false;
    }


    public static void SubtractLife() //static methods can only mess with static variables
    {
        HP--;
        Debug.Log($"Hit Enemy! HP Left: {HP}");

        if (HP == 0)
        {
            //Game Over
            _gameOver = true;
            Debug.Log("Game Over!");
        }


    }

    //eof
}
