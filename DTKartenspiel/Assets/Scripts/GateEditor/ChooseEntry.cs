using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for the ChooseEntry UI Element in the GateEditor. It will open, when the Player clicks on a LogicalGate. 
/// Now the Input of the Gate can be choosen.
/// </summary>
public class ChooseEntry : MonoBehaviour
{
    [Tooltip("The A Toggle")] public Toggle A;
    [Tooltip("The B Toggle")] public Toggle B;
    [Tooltip("The C Toggle")] public Toggle C;
    [Tooltip("The D Toggle")] public Toggle D;

    /// <summary>
    /// The Gate which was clicked on.
    /// </summary>
    private LogicalGate caller;

    void Update()
    {
        if(caller != null && SetCheckmark())
        {
            char entry = CheckedValue();
            RefreshToogle();
            caller.SetEntry(entry);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called by the Gate
    /// </summary>
    /// <param name="caller">The Gate which was clicked on.</param>
    public void RegisterCaller(LogicalGate caller)
    {
        this.caller = caller;
    }

    #region privateMethods
    private char CheckedValue()
    {
        if (A.isOn) return 'A';
        else if (B.isOn) return 'B';
        else if (C.isOn) return 'C';
        else return 'D';
    }

    private bool SetCheckmark()
    {
        if (A.isOn || B.isOn || C.isOn || D.isOn)
            return true;
        else
            return false;
    }

    private void RefreshToogle()
    {
        A.isOn = false;
        B.isOn = false;
        C.isOn = false;
        D.isOn = false;
    }
    #endregion
}
