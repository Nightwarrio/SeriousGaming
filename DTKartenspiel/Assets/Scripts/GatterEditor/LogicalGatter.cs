using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalGatter : MonoBehaviour
{
    [Header("Entrys")]
    public bool entry1;
    public bool entry2;

    //must be override
    public virtual bool Calculate(){return true;}
}
