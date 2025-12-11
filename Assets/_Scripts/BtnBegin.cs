using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnBegin : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("LargeField");
    }
}
