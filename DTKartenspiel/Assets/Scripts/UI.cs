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
    public GameObject text1, text2, exitGame, gatterEditor;

    // Update is called once per frame
    private void Start()
    {
        obj = this.transform.GetChild(0).gameObject;
        team = obj2.GetComponent<CameraScript>().getTeam();
        player = obj2.GetComponent<CameraScript>().getPlayerNumber();
        
        score[0] = 0;
        score[1] = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            if (obj.activeSelf == true)
            {
                obj.SetActive(false);
            }
            else {
                obj.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitGame.activeInHierarchy) exitGame.SetActive(false);
            else exitGame.SetActive(true);
        }
    }

    
    public void onPressedA() {
        // get solution 
        if (team == 0) {
            score[0] = score[0] + 10;
            text1.GetComponent<Text>().text = "Team1 : " + score[0];
        }
        else {
            score[1] = score[1] + 10;
            text2.GetComponent<Text>().text = "Team2 :" + score[1];
        }
        //else switch turn
    }

    public void onPressedB() {
        if (team == 0)
        {
            score[0] = score[0] + 10;
            text1.GetComponent<Text>().text = "Team1 : " + score[0];
        }
        else
        {
            score[1] = score[1] + 10;
            text2.GetComponent<Text>().text = "Team2 :" + score[1];
        }
    }

    public void onPressedC()
    {
        if (team == 0)
        {
            score[0] = score[0] + 10;
            text1.GetComponent<Text>().text = "Team1 : " + score[0];
        }
        else
        {
            score[1] = score[1] + 10;
            text2.GetComponent<Text>().text = "Team2 :" + score[1];
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        if (gatterEditor.activeInHierarchy) gatterEditor.SetActive(false);
        exitGame.SetActive(false);
    }
}
