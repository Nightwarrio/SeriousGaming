﻿using UnityEngine;

/// <summary>
/// This Class represents the UsedCard-Stack
/// </summary>
public class UsedCards : MonoBehaviour
{
    public static UsedCards instance;

    private int size = 0;

    void Start()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Pull the UsedCardStack out of the table
    /// </summary>
    public void Grow()
    {
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
