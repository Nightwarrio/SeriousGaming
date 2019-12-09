using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour
{
    public GameObject gatterEditor;

    public void OnMouseDown()
    {
        gatterEditor.SetActive(true);
        ShowTask();
    }

    private void ShowTask()
    {
        string name = GameCard.instance.name;
        //int index = CardManager.instance.actionCardSet.FindIndex(c => c.id == name);
        //FindObjectOfType<Task>().SetMaterial(CardManager.instance.taskSet[0].tex);
        //Debug.Log(index);
        //Debug.Log(CardManager.instance.actionCardSet[index].id);
        char number = name[name.Length-5];
        Debug.Log(name);
        Debug.Log(number);
        var taskToShow = CardManager.instance.taskSet[0];
        FindObjectOfType<Task>().SetSprite(taskToShow.tex);
    }
}
