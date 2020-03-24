using UnityEngine;

/// <summary>
/// This Class represents the ActionCard Type
/// </summary>
public class ActionCard : Card
{
    public ActionCard(string id, Texture2D tex)
    {
        base.id = id;
        base.tex = tex;
    }

    /// <summary>
    /// Find the Index of the right Solution in the SolutionPanel
    /// </summary>
    /// <returns>The Index of the right Solution</returns>
    public static int FindSolutionIndex()
    {
        string name = GameCard.instance.cardName;
        string[] tmp = name.Split('_'); //Example: Card_action_12
        string number = tmp[tmp.Length - 1]; //Example: 12

        return int.Parse(number);
    }
}
