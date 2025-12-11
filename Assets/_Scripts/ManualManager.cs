using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public GameObject[] malPages; //Array of manual pages
    public bool lookMan;
    public int malMark;

    // Start is called before the first frame update
    void Start()
    {
        lookMan = false;
        malMark = 0;

        malPages[0].SetActive(false);
        malPages[1].SetActive(false);
        malPages[2].SetActive(false);
        malPages[3].SetActive(false);
        malPages[4].SetActive(false);
        malPages[5].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (lookMan)
        {
            malPages[malMark].SetActive(true);
        }
        else
        {
            malPages[malMark].SetActive(false);
        }


    }

    public void ReadIn()
    {
        lookMan = true;
    }

    public void ReadOut()
    {
        lookMan = false;
    }

    public void PrevPage()
    {
        malMark -= 1; //Goes to the previous page
        malPages[malMark + 1].SetActive(false); //Closes the page you were on
    }

    public void NextPage()
    {
        malMark += 1; //Goes to the previous page
        malPages[malMark - 1].SetActive(false); //Closes the page you were on
    }

}
