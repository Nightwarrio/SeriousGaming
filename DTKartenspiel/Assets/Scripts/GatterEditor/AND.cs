using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND : LogicalGatter
{
    public override bool Calculate()
    {
        return entry1 && entry2;
    }
}
