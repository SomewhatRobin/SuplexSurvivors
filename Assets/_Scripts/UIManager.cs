using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreboardTMP;
    public TextMeshProUGUI DebugCmbTMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        if (GameManager.combineValue > 0.00001f)
        {
            DebugCmbTMP.text = GameManager.combineValue.ToString("#.000000");
        }

        else 
        {
            DebugCmbTMP.text = "Nothing";
        }

    }

    

}
