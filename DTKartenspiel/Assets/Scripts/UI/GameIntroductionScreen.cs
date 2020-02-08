using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntroductionScreen : Screen
{
    public void NextIntroPage()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Introduction_FirstPage" && transform.GetChild(i).gameObject.activeSelf == true)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(i + 1).gameObject.SetActive(true);
                break;
            }
            else if (transform.GetChild(i).gameObject.name == "Introduction_GatterPage" && transform.GetChild(i).gameObject.activeSelf == true)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(i + 1).gameObject.SetActive(true);
                break;
            }

        }
    }

    public void PrevIntroPage()
    {

        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).gameObject.name == "Introduction_FirstPage" && 
                transform.GetChild(i + 1).gameObject.name == "Introduction_GatterPage" && transform.GetChild(i + 1).gameObject.activeSelf == true)
            {
                transform.GetChild(i + 1).gameObject.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
            else if (transform.GetChild(i).gameObject.name == "Introduction_GatterPage" 
                && transform.GetChild(i + 1).gameObject.name == "Introduction_KeyBindings" && transform.GetChild(i + 1).gameObject.activeSelf == true)
            {
                transform.GetChild(i + 1).gameObject.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}
