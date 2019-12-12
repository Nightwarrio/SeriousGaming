using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public void SetSprite()
    {
        string name = GameCard.instance.cardName;
        char number = name[name.Length - 5];
        int index = number - 48 - 1; //48 wegen ascii und -1 weil unser set bei 0 beginnt
        var taskToShow = CardManager.instance.taskSet[index]; 
        Sprite sprite = Sprite.Create(taskToShow.tex, 
            new Rect(0, 0, taskToShow.tex.width, taskToShow.tex.height), new Vector2(0, 0));
        this.GetComponent<Image>().sprite = sprite;
    }
}
