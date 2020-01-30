using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GameObject[] arrayOfObjects, introPages;
    private int childrenCount;
    private GameObject obj;
    public GameObject obj2;
    private int player;
    private int team;
    private int[] score = new int[2];
    public GameObject text1, text2, exitGame, gatterEditor, winPoints1, winPoints2, bar1, bar2; // new bar
    private int cardScore;
    private bool gameInProgress, answerGiven;
    private float barMultiplier; // new;
    private Vector3 scaleBar1, scaleBar2, standard; // new
    private GameObject wrong, right, win, cardsLeft, tester, countdown, introduction;

    // Update is called once per frame
    private void Start()
    {
        childrenCount = transform.childCount;
        arrayOfObjects = new GameObject[childrenCount];
        for (int i = 0; i < childrenCount; i++)
        {
            arrayOfObjects[i] = transform.GetChild(i).gameObject;
        }

        //initialize the childObjects of UI
        for (int i = 0; i < arrayOfObjects.Length; i++) {
            if (arrayOfObjects[i].gameObject.tag == "card")
                obj = arrayOfObjects[i];
                if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "WrongAnswer")
                    wrong = arrayOfObjects[i];
                else if (arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "RightAnswer")
                    right = arrayOfObjects[i];
                else if(arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "WinScreen")
                    win = arrayOfObjects[i];
                else if(arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name == "IntroductionWindow")
                    introduction = arrayOfObjects[i];
                else if(arrayOfObjects[i].gameObject.tag == "left?")
                    cardsLeft = arrayOfObjects[i];
                else if(arrayOfObjects[i].gameObject.tag == "countdown")
                      countdown = arrayOfObjects[i];

                else if(arrayOfObjects[i].gameObject.tag == "okTag" && arrayOfObjects[i].gameObject.name =="TesterSkipWindow")   // für tester field
                tester = arrayOfObjects[i];
        }
        team = obj2.GetComponent<CameraScript>().getTeam();
        player = obj2.GetComponent<CameraScript>().getPlayerNumber();

        // score of the Teams
        score[0] = 0;
        score[1] = 0;
        gameInProgress = true;
        answerGiven = true;

        barMultiplier = 1/7;
        standard = new Vector3(0f,1f,1f);
        scaleBar1 = new Vector3(barMultiplier,0f,0f);
        scaleBar2 = new Vector3(barMultiplier,0f,0f);


    }

    public void setanswerGivenFalse()
    {
        answerGiven = false;
    }

    public void setanswerGivenTrue()
    {
        answerGiven = true;
    }

    public bool getAnswerGiven()
    {
        return answerGiven;
    }

    // mostly handles the keybindings
    void Update()
    {
        if (gameInProgress)
        {
            if (Input.GetKeyDown(KeyCode.K) && !answerGiven && !(GetComponent<CountdownScript>().getAlreadyWrong())) // neuer guard
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

            if (Input.GetKeyDown(KeyCode.S)) { //TODO::Funktion nur für die tester zum aufgaben skipen
                setanswerGivenTrue();
                tester.SetActive(true);
                if(obj.activeSelf==true){
                  obj.SetActive(false);
                }
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
                prevIntroPage();
                prevIntroPage();
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

    public void nextIntroPage()
    {
        for(int i = 0; i < introduction.transform.childCount; i++){
          if(introduction.transform.GetChild(i).gameObject.name == "Introduction_FirstPage" && introduction.transform.GetChild(i).gameObject.activeSelf == true){
            introduction.transform.GetChild(i).gameObject.SetActive(false);
            introduction.transform.GetChild(i+1).gameObject.SetActive(true);
            break;
          }
          else if(introduction.transform.GetChild(i).gameObject.name == "Introduction_GatterPage" && introduction.transform.GetChild(i).gameObject.activeSelf == true){
            introduction.transform.GetChild(i).gameObject.SetActive(false);
            introduction.transform.GetChild(i+1).gameObject.SetActive(true);
            break;
          }

    }
  }
    public void prevIntroPage(){

      for(int i = 0; i < introduction.transform.childCount; i++){

        if(introduction.transform.GetChild(i).gameObject.name == "Introduction_FirstPage" && introduction.transform.GetChild(i+1).gameObject.name == "Introduction_GatterPage" && introduction.transform.GetChild(i+1).gameObject.activeSelf == true){
          introduction.transform.GetChild(i+1).gameObject.SetActive(false);
          introduction.transform.GetChild(i).gameObject.SetActive(true);
          break;
        }
        else if(introduction.transform.GetChild(i).gameObject.name == "Introduction_GatterPage" && introduction.transform.GetChild(i+1).gameObject.name == "Introduction_KeyBindings" && introduction.transform.GetChild(i+1).gameObject.activeSelf == true){
          introduction.transform.GetChild(i+1).gameObject.SetActive(false);
          introduction.transform.GetChild(i).gameObject.SetActive(true);
          break;
        }
      }
    }

    //adds points for right component
    public void gatterPoints(){
      if (team == 0)
      {
          score[0] = score[0] + 5;
          text1.GetComponent<Text>().text = "Team1 : " + score[0];
          calculateHealthBar(score[0], 1);
      }
      else
      {
          score[1] = score[1] + 5;
          text2.GetComponent<Text>().text = "Team2 : " + score[1];
          calculateHealthBar(score[1], 0);
      }
    }

    public void removePoints(){
      if (team == 0)
      {
          score[0] = score[0] - 5;
          text1.GetComponent<Text>().text = "Team1 : " + score[0];
      }
      else
      {
          score[1] = score[1] - 5;
          text2.GetComponent<Text>().text = "Team2 : " + score[1];
      }
    }


    private void calculateHealthBar(int score, int team){
        if(team == 1){
          bar1.gameObject.transform.localScale = standard;
          bar1.gameObject.transform.localScale += (scaleBar1 *score);
        }
        else{
          bar2.gameObject.transform.localScale = standard;
          bar2.gameObject.transform.localScale += (scaleBar1 *score);
        }
    }



    // Manages Points für right/wrong answers and checks the pressed button
    public void onPressedA()
    {
        // get solution
        if (gameInProgress)
        {

            cardScore = GameCard.instance.points;
            switch (GameCard.instance.getSolution())
            {
                case 'a':
                    if (team == 0)
                    {
                        score[0] = score[0] + cardScore;
                        text1.GetComponent<Text>().text = "Team1 : " + score[0];
                        calculateHealthBar(score[0], 1);
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                        calculateHealthBar(score[1], 0);
                    }
                    right.gameObject.SetActive(true);
                    break;
                default:
                    wrong.gameObject.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
                win.SetActive(true);
            }
        }

    }
// Manages Points für right/wrong answers and checks the pressed button
    public void onPressedB()
    {
        if (gameInProgress)
        {
            cardScore = GameCard.instance.points;
            switch (GameCard.instance.getSolution())
            {
                case 'b':
                    if (team == 0)
                    {
                        score[0] = score[0] + cardScore;
                        text1.GetComponent<Text>().text = "Team1 : " + score[0];
                        calculateHealthBar(score[0], 1);
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                        calculateHealthBar(score[1], 0);
                    }
                    right.gameObject.SetActive(true);
                    break;
                default:
                    wrong.gameObject.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
              win.SetActive(true);
            }
        }
    }
// Manages Points für right/wrong answers and checks the pressed button
    public void onPressedC()
    {
        if (gameInProgress)
        {
            cardScore = GameCard.instance.points;
            switch (GameCard.instance.getSolution())
            {
                case 'c':
                    if (team == 0)
                    {
                        score[0] = score[0] + cardScore;
                        text1.GetComponent<Text>().text = "Team1 : " + score[0];
                        calculateHealthBar(score[0], 1);
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                        calculateHealthBar(score[1], 0);
                    }
                    right.SetActive(true);
                    break;
                default:
                    wrong.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
                win.SetActive(true);
            }
        }
    }
    // exits the game
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        if (gatterEditor.activeInHierarchy)
        {
            gatterEditor.SetActive(false);
            CraftingPanel.instance.ClearPanel(); //TODO:: delete; nur für die alphaVersion benötigt, da die ActionCard nich gelöst werden muss
        }
        exitGame.SetActive(false);
    }
}
