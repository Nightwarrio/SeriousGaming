using UnityEngine;

/// <summary>
/// This Class represents the QuestionCard Type
/// </summary>
public class QuestionCard : Card
{
    public enum Level { EASY, MEDIUM, HARD };

    private int points;
    private char solution;
    private Level level;

    public QuestionCard(string id, Level level, Texture2D tex)
    {
        base.id = id;
        this.level = level;
        base.tex = tex;

        SetPoints();
        SetSolution();
    }

    public int GetPoints(){ return points; }
    public char GetSolution() { return solution; }

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
        solution = id[id.Length - 1];
    }
}
