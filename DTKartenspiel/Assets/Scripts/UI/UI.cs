using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;

    public GameObject wrongAnswer;
    public GameObject rightAnswer;
    public GameObject winScreen;
    public GameObject diceInstruction;
    public GameObject instructionWindow;
    public GameObject startScreen;
    public GameObject timeOver;
    public GameObject reminder;
    public GameObject dice;
    public GameObject currentPlayer;
    public GameObject playerName; //the fadingObject
    public GameObject obj2; //TODO:: rename this
    public GameObject exitGame, gatterEditor;

    private GameObject[] arrayOfObjects;
    private int childrenCount;
    private GameObject obj;
    private GameObject wrong, right, win, keybindings, cardsLeft, tester, countdown, introduction;


    private void Start()
    {
        if (instance == null) instance = this;

        childrenCount = transform.childCount;
        arrayOfObjects = new GameObject[childrenCount];
        for (int i = 0; i < childrenCount; i++)
        {
            arrayOfObjects[i] = transform.GetChild(i).gameObject;
        }

        //initialize the childObjects of UI
        for (int i = 0; i < arrayOfObjects.Length; i++)
        {
            if (arrayOfObjects[i].gameObject.tag == "card")
                obj = arrayOfObjects[i];
            if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "WrongAnswer")
                wrong = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "RightAnswer")
                right = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "WinScreen")
                win = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "keybinding")
                keybindings = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "IntroductionWindow")
                introduction = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "left?")
                cardsLeft = arrayOfObjects[i];
            else if (arrayOfObjects[i].gameObject.tag == "countdown")
                countdown = arrayOfObjects[i];

            else if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "TesterSkipWindow")   // für tester field
                tester = arrayOfObjects[i];
        }
    }

    #region showPanels
    public void ShowTimeOverScreen()
    {
        timeOver.SetActive(true);
    }

    /// <summary>
    /// show the screen and stops the music
    /// </summary>
    public void ShowWinScreen()
    {

        winScreen.GetComponent<WinScreen>().UpdateScreen();
        winScreen.SetActive(true);
        AudioManager.instance.StopMusic();
    }

    public void ShowReminderScreen()
    {
        reminder.SetActive(true);
    }

    public void ShowStartScreen(int startingTeam)
    {
        startScreen.GetComponent<StartScreen>().SetTeamNumber(startingTeam);
        startScreen.SetActive(true);
    }

    public void ShowInstructionWindow()
    {
        instructionWindow.SetActive(true);
    }

    public void ShowDiceInstructionScreen()
    {
        diceInstruction.SetActive(true);
    }

    public void ShowRightAnswerScreen()
    {
        rightAnswer.GetComponent<RightAnswer>().SetText();
        rightAnswer.SetActive(true);
    }

    public void ShowWrongAnswerScreen()
    {
        wrongAnswer.SetActive(true);
    }
    #endregion

    public void SetCurrentPlayer(string name, int number)
    {
        currentPlayer.GetComponent<Text>().text = "Current Player: " + name + " in Team " + number;
    }

    // mostly handles the keybindings
    void Update()
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
            if (exitGame.activeInHierarchy) exitGame.SetActive(false);
            else exitGame.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (introduction.activeSelf == true)
            {
                introduction.SetActive(false);
            }
            else
            {
                introduction.SetActive(true);
            }
        }
    }
  
    /// <summary>
    /// closes ALL UI-Windows with okTag (WrondAnswer/RightAnswer/GiveAnswer/TesterSkipWindow/InitializeCountdown/IntroductionWindow)
    /// </summary>
    public void okButton()
    {
        for (int i = 0; i < arrayOfObjects.Length; i++) {
            if (arrayOfObjects[i].gameObject.tag == "okTag") {
                arrayOfObjects[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// show the current Player name in the middle of the table
    /// </summary>
    public void ShowPlayerName(string name)
    {
        var tmp = Instantiate(playerName, Vector3.zero, Quaternion.identity);
        tmp.transform.SetParent(gameObject.transform, false);

        var text = "It's your turn " + name + "!";
        tmp.GetComponent<FadingObject>().text.GetComponent<Text>().text = text;

        tmp.GetComponent<FadingObject>().lifetime = 0.5f;
    }

    #region close Panels
    /// <summary>
    /// Close the panel and activate the dice 
    /// </summary>
    public void CloseDiceInstruction()
    {
        diceInstruction.SetActive(false);
        dice.SetActive(true);
    }

    public void ClosePanel_StartNextTurn()
    {
        wrongAnswer.SetActive(false);
        rightAnswer.SetActive(false);
        timeOver.SetActive(false);

        ScreenCard.instance.EndTurn();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        exitGame.SetActive(false);
        reminder.SetActive(false);
    }
    #endregion
}
