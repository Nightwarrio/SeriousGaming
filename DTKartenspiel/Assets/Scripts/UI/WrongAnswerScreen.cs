/// <summary>
/// Manages the WrongAnswerScreen UI Element
/// </summary>
public class WrongAnswerScreen : Screen
{
    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }
}
