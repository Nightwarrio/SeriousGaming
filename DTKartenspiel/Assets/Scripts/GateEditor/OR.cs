/// <summary>
/// Class for the Logical OR
/// </summary>
public class OR : LogicalGate
{
    public override bool Calculate()
    {
        return entry1 || entry2;
    }
}
