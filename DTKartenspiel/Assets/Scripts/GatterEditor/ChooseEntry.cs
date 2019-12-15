using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseEntry : MonoBehaviour
{
    private Toggle A, B, C, D;
    private LogicalGatter caller;

    private void Update()
    {
        if(caller != null && SetCheckmark())
        {
            char entry = CheckedValue();
            RefreshToogle();
            caller.SetValue(entry);
            gameObject.SetActive(false);
        }
    }

    public bool SetCheckmark()
    {
        A = GameObject.FindGameObjectsWithTag("ToggleA")[0].GetComponent<Toggle>();
        B = GameObject.FindGameObjectsWithTag("ToggleB")[0].GetComponent<Toggle>();
        C = GameObject.FindGameObjectsWithTag("ToogleC")[0].GetComponent<Toggle>();
        D = GameObject.FindGameObjectsWithTag("ToogleD")[0].GetComponent<Toggle>();

        if (A.isOn || B.isOn || C.isOn || D.isOn)
            return true;
        else
            return false;
    }

    public void RegisterCaller(LogicalGatter caller)
    {
        this.caller = caller;
    }

    public char CheckedValue()
    {
        if (A.isOn) return 'A';
        else if (B.isOn) return 'B';
        else if (C.isOn) return 'C';
        else return 'D';
    }

    public void RefreshToogle()
    {
        A.isOn = false;
        B.isOn = false;
        C.isOn = false;
        D.isOn = false;
    }
}
