using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class represents the GameCard-Object
/// </summary>
public class GameCard : MonoBehaviour
{
    public static GameCard instance;

    [Tooltip("The ScreenCard Object")] public GameObject screenCard;

    [Header("Controlls for the developer")]
    public string cardName;
    public int points;
    public bool isActionCard;

    [Header("Solutions")]
    public bool a;
    public bool b;
    public bool c;

    private char cardSolution;

    private void Start()
    {
        if (instance == null)  instance = this;
    }

    /// <summary>
    /// Pull the GameCard at the first turn out of the table
    /// </summary>
    public void Reveal()
    {
        transform.position = new Vector3(transform.position.x, 0.98f, transform.position.z);
    }

    public char GetSolution() { return cardSolution; }

    #region setter

    /// <summary>
    /// set the Texture of the GameCard and also for the ScreenCard
    /// </summary>
    /// <param name="tex">The Texture2D</param>
    public void SetMaterial(Texture2D tex)
    {
        this.GetComponent<MeshRenderer>().material.mainTexture = tex;
        screenCard.GetComponent<Image>().sprite = CardManager.instance.TexToSprite(tex);
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

    public void SetPoints(int points) { this.points = points; }

    public void SetStatusToActionCard() { isActionCard = true; }

    public void SetName(string id) { cardName = id; }
    #endregion
}
