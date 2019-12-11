using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : LogicalGatter
{
    public override bool Calculate()
    {
        return !entryNotGatter;
    }
}
