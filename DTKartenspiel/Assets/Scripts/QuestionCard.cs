using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCard : Card
{
    public enum Level { EASY, MEDIUM, HARD };
    private int points = 0;
    private char solution;
    private Level level;


    public QuestionCard(string id, Level level, Texture2D tex)
    {
        base.id = id;
        this.level = level;
        base.tex = tex;
        base.isActionCard = false;
        SetPoints();
        SetSolution();
    }

    //Private Methods//
    private void SetPoints()
    {
        switch (level)
        {
            case Level.EASY:
                points = 10;
                break;
            case Level.MEDIUM:
                points = 20;
                break;
            case Level.HARD:
                points = 50;
                break;
            default:
                break;
        }
    }
    private void SetSolution()
    {
        solution = id[id.Length - 5]; //xy.jpg, wobei 'g' -1 wäre
        Debug.Log(solution);
    }
}
