using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XNOR : LogicalGatter
{
    public override bool Calculate()
    {
        return (entry1 && entry2) || !(entry1 && entry2);
    }
}
