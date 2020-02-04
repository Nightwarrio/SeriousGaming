using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightAnswer : MonoBehaviour
{
    public GameObject pointText;
   
    public void SetText()
    {
        pointText.GetComponent<Text>().text = "You earn " + GameCard.instance.points + " points!";
    }
}
