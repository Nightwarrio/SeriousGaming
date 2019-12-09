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
        FindObjectOfType<Task>().SetSprite();
        FindObjectOfType<SolutionPanel>().SetSprite();
    }
}
