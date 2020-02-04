using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedCards : MonoBehaviour
{
    public static UsedCards instance;
    private int size = 0;

    void Start()
    {
        if (instance == null) instance = this;
    }

    public void Grow()
    {
        if (CardStack.instance.firstTurn) return; //erst bei der zweiten Karte abwerfen

        size++;
        Vector3 tmp = new Vector3(0, 0.0076f, 0);
        switch (size)
        {
            case 1:
                transform.position += tmp;
                break;
            case 5:
                transform.position += tmp;
                break;
            case 15:
                transform.position += tmp;
                break;
            case 25:
                transform.position = new Vector3(transform.position.x, 1.02f, transform.position.z);
                break;
            default:
                break;
        }
    }
}
