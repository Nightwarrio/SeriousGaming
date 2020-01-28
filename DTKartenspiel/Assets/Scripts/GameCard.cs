using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public static GameCard instance;
    public GameObject UiImage, startAction;
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
    /// deckt die erste Karte auf
    /// </summary>
    public void Reveal()
    {
        transform.position = new Vector3(transform.position.x, 0.98f, transform.position.z);
    }

    public char getSolution()
    {
        return cardSolution;
    }

    #region setter
    public void SetMaterial(Texture2D tex)
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = tex;
        sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100.0f);
        UiImage.GetComponent<Image>().sprite = sprite;
    }

    public void SetSolution(char s)
    {
        startAction.SetActive(false); //TODO:: delete; nur für die alphaVersion benötigt, da man noch Karten überspringen kann

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
        cardSolution = s;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }

    public void SetStatusToActionCard()
    {
        isActionCard = true;
        startAction.SetActive(true); //now the button to the editorWindow is active
    }

    public void SetName(string id)
    {
        this.cardName = id;
    }
    #endregion
}
