/// <summary>
/// Class for the Logical XOR
/// </summary>
public class XOR : LogicalGate
{
    public override bool Calculate()
    {
        if (entry1 && entry2) return false;
        else return (entry1 || entry2);
    }
}
