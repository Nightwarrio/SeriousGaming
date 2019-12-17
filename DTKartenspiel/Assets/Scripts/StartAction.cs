using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour
{
    public GameObject gatterEditor, task, solutionPanel, UI;

    public void OnMouseDown()
    {
        //UI.GetComponent<UI>().setanswerGivenTrue(); //damit in cardStack bei draw der cardStack wächst
        gameObject.SetActive(false); //deactivate this, so the next card can't open the editor
        gatterEditor.SetActive(true);
        task.GetComponent<Task>().SetSprite();
        int index = FindSolutionIndex();

        solutionPanel.GetComponent<SolutionPanel>().PrepareSolutions();

        if (GameCard.instance.cardName[0] == 'n')
        {
            Debug.Log("Card is not implemented yet!");
            gatterEditor.SetActive(false);
            UI.GetComponent<UI>().setanswerGivenTrue();
            UI.transform.GetChild(0).gameObject.SetActive(false);
            return;
        }
        else
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
