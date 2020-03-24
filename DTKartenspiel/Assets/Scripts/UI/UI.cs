using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Manges the UI Parent Element in the Unity Hierachie. Interface for the Classes to the other ScreenObjects
/// </summary>
public class UI : MonoBehaviour
{
    public static UI instance;

    public GameObject wrongAnswerScreen;
    public GameObject rightAnswerScreen;
    public GameObject winScreen;
    public GameObject gameIntroductionScreen;
    public GameObject startScreen;
    public GameObject timeOverScreen;
    public GameObject reminderScreen;
    public GameObject exitGameScreen;
    public GameObject dice;
    public GameObject currentPlayer;
    public GameObject playerName; //the fadingObjec
    public GameObject cardsLeft;
    public GameObject gatterEditor;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    #region showScreens
    public void ShowTimeOverScreen()
    {
        timeOverScreen.GetComponent<TimeOverScreen>().ShowScreen();
    }

    public void ShowWinScreen()
    {
        winScreen.GetComponent<WinScreen>().ShowScreen();
    }

    public void ShowReminderScreen()
    {
        reminderScreen.GetComponent<ReminderScreen>().ShowScreen();
    }

    public void ShowStartScreen(int startingTeam)
    {
        startScreen.GetComponent<StartScreen>().TeamNumber = startingTeam;
        startScreen.GetComponent<StartScreen>().ShowScreen();
    }

    public void ShowRightAnswerScreen()
    {
        rightAnswerScreen.GetComponent<RightAnswerScreen>().ShowScreen();
    }

    public void ShowWrongAnswerScreen()
    {
        wrongAnswerScreen.GetComponent<WrongAnswerScreen>().ShowScreen();
    }
    #endregion

    public void UpdateCardsLeft(int stackSize)
    {
        cardsLeft.GetComponent<Text>().text = "Cards Left: " + stackSize;
    }

    /// <summary>
    /// Update the CurrentPlayer Text at the Bottom
    /// </summary>
    /// <param name="name">Name of the Player</param>
    /// <param name="number">TeamNumber of the Player</param>
    public void SetCurrentPlayer(string name, int number)
    {
        currentPlayer.GetComponent<Text>().text = "Current Player: " + name + " in Team " + number;
    }

   
    void Update()  //Handles the Keybindings
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (cardsLeft.activeSelf == true)
            {
                cardsLeft.SetActive(false);
            }
            else
            {
                cardsLeft.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitGameScreen.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gameIntroductionScreen.activeSelf == true)
            {
                gameIntroductionScreen.SetActive(false);
            }
            else
            {
                gameIntroductionScreen.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Show the current Player Name fading in the Middle of the Table.
    /// </summary>
    public void ShowPlayerName(string name)
    {
        var tmp = Instantiate(playerName, Vector3.zero, Quaternion.identity);
        tmp.transform.SetParent(gameObject.transform, false);

        var text = "It's your turn " + name + "!";
        tmp.GetComponent<FadingObject>().text.GetComponent<Text>().text = text;

        tmp.GetComponent<FadingObject>().lifetime = 0.5f;
    }
}
