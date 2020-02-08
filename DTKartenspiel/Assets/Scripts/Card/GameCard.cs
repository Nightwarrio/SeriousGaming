using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public static GameCard instance;
    public GameObject screenCard;
    public string cardName;
    public int points;
    public bool isActionCard;

    private Sprite sprite;
    private char cardSolution;

    [Header("Solutions")]
    public bool a;
    public bool b;
    public bool c;

    private void Start()
    {
        if (instance == null)  instance = this;
    }

    /// <summary>
    /// Die Karte liegt zu Beginn noch unter dem Tisch und muss nach oben gezogen werden
    /// </summary>
    public void Reveal()
    {
        transform.position = new Vector3(transform.position.x, 0.98f, transform.position.z);
    }

    public char GetSolution()
    {
        return cardSolution;
    }

    #region setter
    public void SetMaterial(Texture2D tex)
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = tex;
        sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100.0f);
        screenCard.GetComponent<Image>().sprite = sprite;
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
                Debug.Log("No valid solution given!");
                break;
        }
        cardSolution = s;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }

    public void SetStatusToActionCard()
    {
        isActionCard = true;
    }

    public void SetName(string id)
    {
        this.cardName = id;
    }
    #endregion
}
