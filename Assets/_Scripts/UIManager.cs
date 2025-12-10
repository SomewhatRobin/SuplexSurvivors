using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreboardTMP;
    public TextMeshProUGUI DebugCmbTMP;
    public TextMeshProUGUI DebugCmb1TMP;
    public TextMeshProUGUI DebugCmb2TMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        //Snake Combo View
        if (GameManager.combineValue > 0.00001f)
        {
            DebugCmbTMP.text = GameManager.combineValue.ToString("#.000000");
        }

        else 
        {
            DebugCmbTMP.text = "Nothing";
        }

        //Knight Combo view
        if (GameManager.combineValue1 > 0.00001f)
        {
            DebugCmb1TMP.text = GameManager.combineValue1.ToString("#.000000");
        }

        else
        {
            DebugCmb1TMP.text = "Nothing";
        }

        //Car Combo view
        if (GameManager.combineValue2 > 0.00001f)
        {
            DebugCmb2TMP.text = GameManager.combineValue2.ToString("#.000000");
        }

        else
        {
            DebugCmb2TMP.text = "Nothing";
        }

    }

    

}
