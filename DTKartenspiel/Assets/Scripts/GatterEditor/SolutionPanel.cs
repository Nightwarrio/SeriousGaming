using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPanel : MonoBehaviour
{
    public void SetSprite()
    {
        string name = GameCard.instance.cardName;
        char number = name[name.Length - 5];
        int index = number - 48 - 1; //48 wegen ascii und -1 weil unser set bei 0 beginnt
        var solutionToLoad = CardManager.instance.solutionSet[index];
        Sprite sprite = Sprite.Create(solutionToLoad.tex,
            new Rect(0, 0, solutionToLoad.tex.width, solutionToLoad.tex.height), new Vector2(0, 0));
        this.GetComponent<Image>().sprite = sprite;
    }
}
