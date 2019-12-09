using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NOT : LogicalGatter
{
    public override bool Calculate()
    {
        return !entryNotGatter;
    }

    
}
