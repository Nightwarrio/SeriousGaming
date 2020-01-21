using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XOR : LogicalGatter
{
    public override bool Calculate()
    {
        if (entry1 && entry2) return false;
        else return (entry1 || entry2);
    }
}
