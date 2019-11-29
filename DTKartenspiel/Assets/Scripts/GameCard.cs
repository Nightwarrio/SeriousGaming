using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public bool isActionCard;

    [Header("Solutions")]
    public bool a;
    public bool b;
    public bool c;

    public void SetMaterial(Texture2D tex)
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = tex;
    }

    public void SetSolution(char s)
    {
        switch (s)
        {
            case 'a':
                a = true;
                b = false;
                c = false;
                break;
            case 'b':
                a = false;
                b = true;
                c = false;
                break;
            case 'c':
                a = false;
                b = false;
                c = true;
                break;
            default:
                break;
        }
    }
}
