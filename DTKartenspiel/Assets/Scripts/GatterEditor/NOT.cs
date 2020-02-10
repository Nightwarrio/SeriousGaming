/// <summary>
/// Class for the Logical NOT. This Gate is a speciall Cace of the Gates, because there is only one Input!
/// </summary>
public class NOT : LogicalGate
{
    public bool entryNotGatter;

    public override bool Calculate()
    {
        return !entryNotGatter;
    }

    public override void SetEntry(char entry)
    {
        entryNotGatter = true;
        entry1 = true;
        entry2 = true;
        myPlaceholder.SetNotEntry(entry);
    }

    public override bool SetLineEntry()
    {
        bool setLineCorrect = false;

        if (myPlaceholder.needNoLetter)
        {
            if (entryNotGatter)
                setLineCorrect = false;
            else
            {
                setLineCorrect = true;

                //All Inputs have to be true, that the Solution will be accepted
                entryNotGatter = true;
                entry1 = true;
                entry2 = true;
            }
        }

        return setLineCorrect;
    }
}
