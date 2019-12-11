using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour
{
    public GameObject gatterEditor, task, solutionPanel;

    public void OnMouseDown()
    {
        gatterEditor.SetActive(true);
        task.GetComponent<Task>().SetSprite();
        int index = FindSolutionIndex();

        solutionPanel.GetComponent<SolutionPanel>().PrepareSolutions();
        solutionPanel.GetComponent<SolutionPanel>().LoadSolution(index);
    }

    private int FindSolutionIndex()
    {
        string name = GameCard.instance.cardName;
        char number = name[name.Length - 5];
        int index = number - 48 - 1; //48 wegen ascii und -1 weil unser set bei 0 
        return index;
    }
}
