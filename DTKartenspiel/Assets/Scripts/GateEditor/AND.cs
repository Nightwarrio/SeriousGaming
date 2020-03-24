/// <summary>
/// Class for the Logial AND
/// </summary>
public class AND : LogicalGate
{
    public override bool Calculate()
    {
        return entry1 && entry2;
    }
}
