using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Check which Button is pressed to answer the Question and proof the solution
/// </summary>
public class ScreenCard : MonoBehaviour
{
    public GameObject task, solutionPanel, gateEditor, countdown;

    public void OnPressedA()
    {
        if (GameCard.instance.GetSolution() == 'a')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();

        EndTurn();
    }

    public void OnPressedB()
    {
        if (GameCard.instance.GetSolution() == 'b')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();

        EndTurn();
    }

    public void OnPressedC()
    {
        if (GameCard.instance.GetSolution() == 'c')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();

        EndTurn();
    }

    public void StartAction() //GratulationPanel ends the turn
    {
        countdown.GetComponent<CountdownScript>().StartCountdown(300); //start Countdown

        gateEditor.GetComponent<GateEditorManager>().ShowUp();
        gameObject.SetActive(false);

        int index = FindSolutionIndex() - 1; //-1, da Indizies bei 0 beginnen

        SetSprite(index);
        solutionPanel.GetComponent<SolutionPanel>().LoadSolution(index);
    }

    /// <summary>
    /// also called by the solutionPanel
    /// </summary>
    public void EndTurn()
    {
        countdown.GetComponent<CountdownScript>().StopCountdown();
        gameObject.SetActive(false);
        GameManager.instance.NewTurn();
    }

    /// <summary>
    /// called by the countdown when the time is over. 
    /// Close the card and the next player is on turn.
    /// </summary>
    public void TimeOver()
    {
        UI.instance.ShowTimeOverScreen();
        EndTurn();
    }

    #region privateMethods
    /// <summary>
    /// starts the process, when the right answer is clicked
    /// </summary>
    


    private void ProcessRightSolution()
    {
        Score.instance.SetPointsRightAnswer();
        UI.instance.ShowRightAnswerScreen();

        if (GameManager.instance.GameFinishedRecord())
        {
            GameManager.instance.gameInProgress = false;
            UI.instance.ShowWinScreen();
        }
    }

    /// <summary>
    /// find the index of the right solution in the solutionPanel
    /// </summary>
    private int FindSolutionIndex()
    {
        string name = GameCard.instance.cardName;
        string[] tmp = name.Split('_'); //Example: Card_action_12.jpg
        string numberWithJPG = tmp[tmp.Length - 1]; //Example: 12.jpg
        string number = numberWithJPG.Split('.')[0];

        return System.Int32.Parse(number);
    }

    /// <summary>
    /// set the right cardSnippetTask  in the TaskImage
    /// </summary>
    private void SetSprite(int index)
    {
        var taskToShow = CardManager.instance.taskSet[index];
        Sprite sprite = Sprite.Create(taskToShow.tex,
            new Rect(0, 0, taskToShow.tex.width, taskToShow.tex.height), new Vector2(0, 0));
        task.GetComponent<Image>().sprite = sprite;
    }
    #endregion
}
