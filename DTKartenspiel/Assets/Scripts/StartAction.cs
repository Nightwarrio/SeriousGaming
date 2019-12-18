﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour
{
    public GameObject gatterEditor, task, solutionPanel, UI;

    public void OnMouseDown()
    {
        //UI.GetComponent<UI>().setanswerGivenTrue(); //damit in cardStack bei draw der cardStack wächst
        gameObject.SetActive(false); //deactivate this, so the next card can't open the editor
        gatterEditor.SetActive(true);
        
        int index = FindSolutionIndex() - 1; //-1, da Indizies bei 0 beginnen

        SetSprite(index);
        solutionPanel.GetComponent<SolutionPanel>().LoadSolution(index);
    }

    private int FindSolutionIndex()
    {
        string name = GameCard.instance.cardName;
        string[] tmp = name.Split('_'); //Example: Card_action_12.jpg
        string numberWithJPG = tmp[tmp.Length - 1]; //Example: 12.jpg
        string number = numberWithJPG.Split('.')[0];

        return System.Int32.Parse(number);
    }

    private void SetSprite(int index)
    {
        var taskToShow = CardManager.instance.taskSet[index];
        Sprite sprite = Sprite.Create(taskToShow.tex,
            new Rect(0, 0, taskToShow.tex.width, taskToShow.tex.height), new Vector2(0, 0));
        task.GetComponent<Image>().sprite = sprite;
    }
}
