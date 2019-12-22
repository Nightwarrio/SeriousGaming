using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInput : MonoBehaviour
{
    private Line caller;

    void Update()
    {
        if(caller != null)
        {
            transform.parent.GetComponent<LogicalGatter>().SetEntry();
        }
    }

    public void RegisterCaller(Line caller)
    {
        this.caller = caller;
    }
}
