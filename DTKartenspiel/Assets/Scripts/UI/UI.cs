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
    public GameObject obj2; //TODO:: rename this
    public GameObject exitGame, gatterEditor;

    private GameObject[] arrayOfObjects;
    private int childrenCount;
    private GameObject obj;
    private int player;
    private int team;
    private int cardScore;
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
        team = obj2.GetComponent<CameraScript>().getTeam();
        player = obj2.GetComponent<CameraScript>().getPlayerNumber();
    }

    public void ShowTimeOverScreen()
    {
        timeOver.SetActive(false);
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

    /// <summary>
    /// show the screen and stops the music
    /// </summary>
    public void ShowWinScreen()
    {

        winScreen.GetComponent<WinScreen>().UpdateScreen();
        winScreen.SetActive(true);
        AudioManager.instance.StopMusic();
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
    }

    public void SetCurrentPlayer(string name, int number)
    {
        currentPlayer.GetComponent<Text>().text = "Current Player: " + name + " in Team " + number;
    }

    // mostly handles the keybindings
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
        }

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
    /// Close the panel and activate the dice 
    /// </summary>
    public void CloseDiceInstruction()
    {
        diceInstruction.SetActive(false);
        dice.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        exitGame.SetActive(false);
        timeOver.SetActive(false);
        reminder.SetActive(false);
    }

    public void ShowReminderScreen()
    {
        reminder.SetActive(true);
    }
}
