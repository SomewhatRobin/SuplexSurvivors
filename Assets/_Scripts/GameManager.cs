using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static int staMana = 2;
    public static bool _gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        staMana = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
