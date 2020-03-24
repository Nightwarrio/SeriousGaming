/// <summary>
/// Manages the TimeOverScreen UI Element
/// </summary>
public class TimeOverScreen : Screen
{
    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }
}
