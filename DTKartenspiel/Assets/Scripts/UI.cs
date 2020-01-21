using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GameObject obj;
    public GameObject obj2;
    private int player;
    private int team;
    private int[] score = new int[2];
    public GameObject text1, text2, exitGame, gatterEditor, winPoints1, winPoints2;
    private int cardScore;
    private bool gameInProgress, answerGiven;

    // Update is called once per frame
    private void Start()
    {
        obj = this.transform.GetChild(0).gameObject;
        team = obj2.GetComponent<CameraScript>().getTeam();
        player = obj2.GetComponent<CameraScript>().getPlayerNumber();

        score[0] = 0;
        score[1] = 0;
        gameInProgress = true;
        answerGiven = true;
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
    void Update()
    {
        if (gameInProgress)
        {
            if (Input.GetKeyDown(KeyCode.K) && !answerGiven)
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

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (this.transform.GetChild(7).gameObject.activeSelf == true)
                {
                    this.transform.GetChild(7).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(7).gameObject.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (this.transform.GetChild(8).gameObject.activeSelf == true)
                {
                    this.transform.GetChild(8).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(8).gameObject.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitGame.activeInHierarchy) exitGame.SetActive(false);
            else exitGame.SetActive(true);
        }
    }

    public void okButton()
    {
        this.transform.GetChild(10).gameObject.SetActive(false);
        this.transform.GetChild(11).gameObject.SetActive(false);
        this.transform.GetChild(12).gameObject.SetActive(false);
    }


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
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                    }
                    this.transform.GetChild(10).gameObject.SetActive(true);
                    break;
                default:
                    this.transform.GetChild(11).gameObject.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
                this.transform.GetChild(9).gameObject.SetActive(true);
            }
        }

    }

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
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                    }
                    this.transform.GetChild(10).gameObject.SetActive(true);
                    break;
                default:
                    this.transform.GetChild(11).gameObject.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
                this.transform.GetChild(9).gameObject.SetActive(true);
            }
        }
    }

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
                    }
                    else
                    {
                        score[1] = score[1] + cardScore;
                        text2.GetComponent<Text>().text = "Team2 : " + score[1];
                    }
                    this.transform.GetChild(10).gameObject.SetActive(true);
                    break;
                default:
                    this.transform.GetChild(11).gameObject.SetActive(true);
                    break;
            }
            answerGiven = true;
            obj.SetActive(false);
            if (score[0] == 700 || score[1] == 700)
            {
                gameInProgress = false;
                winPoints1.GetComponent<Text>().text = "Team1: " + score[0];
                winPoints2.GetComponent<Text>().text = "Team2: " + score[1];
                this.transform.GetChild(9).gameObject.SetActive(true);
            }
        }
    }

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
