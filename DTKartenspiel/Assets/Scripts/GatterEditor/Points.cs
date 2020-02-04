using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private int points = 0;
    public void SetText()
    {
        points += 5;
        gameObject.GetComponent<Text>().text = "Points: " + points;
    }

    public void Reset()
    {
        points = 0;
    }
}
