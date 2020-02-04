using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : LogicalGatter
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
}
