using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Script for the Points UI Element in the GateEditor on the upper left Corner
/// </summary>
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
