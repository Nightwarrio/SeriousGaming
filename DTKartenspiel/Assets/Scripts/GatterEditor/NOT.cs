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

    public override void SetValue(char entrie)
    {
        switch (entrie)
        {
            case 'A':
                base.A = true;
                base.B = false;
                base.C = false;
                base.D = false;
                break;
            case 'B':
                base.A = false;
                base.B = true;
                base.C = false;
                base.D = false;
                break;
            case 'C':
                base.A = false;
                base.B = false;
                base.C = true;
                base.D = false;
                break;
            case 'D':
                base.A = false;
                base.B = false;
                base.C = false;
                base.D = true;
                break;
        }
    }
}
