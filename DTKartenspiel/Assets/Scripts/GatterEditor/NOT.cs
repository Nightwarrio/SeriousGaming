using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

                //Alle Inputs muessen auf true stehen, damit die Loesung anerkannt wird!
                entryNotGatter = true;
                entry1 = true;
                entry2 = true;
            }
        }

        return setLineCorrect;
    }
}
