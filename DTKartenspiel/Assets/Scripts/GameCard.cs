using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public static GameCard instance;
    public string name;
    public int points;
    public bool isActionCard;

    [Header("Solutions")]
    public bool a;
    public bool b;
    public bool c;

    private void Start()
    {
        if (instance == null)  instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reveal()
    {
        transform.position = new Vector3(transform.position.x, 0.98f, transform.position.z);
    }

    #region setter
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

    public void SetPoints(int points)
    {
        this.points = points;
    }

    public void SetStatusToActionCard()
    {
        isActionCard = true;
        GetComponentInChildren<StartAction>().enabled = true; //now the button to the editorWindow is active
    }

    public void SetName(string id)
    {
        this.name = id;
    }
    #endregion
}
