using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public static GameCard instance;
    public bool isActionCard;
    public int points;
    public GameObject UiImage;

    [Header("Solutions")]
    public bool a;
    public bool b;
    public bool c;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reveal()
    {
        transform.position = new Vector3(transform.position.x, 0.981f, transform.position.z);
    }

    public void SetMaterial(Texture2D tex) //Sprite spr
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = tex;


        // UiImage.GetComponent<Image>().sprite = spr;
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

    public void SetPoints(int points)
    {
        this.points = points;
    }
}
