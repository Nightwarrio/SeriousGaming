using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class represents the ScreenCard UI Element
/// Check which Button is pressed to answer the Question and proof the solution
/// </summary>
public class ScreenCard : MonoBehaviour
{
    public static ScreenCard instance;

    [Tooltip("The Task Element in the GateEditor")] public GameObject task;
    [Tooltip("The SolutionPanel Element in the GateEditor")] public GameObject solutionPanel;
    [Tooltip("The GateEditor Element")] public GameObject gateEditor;
    [Tooltip("The Countdown UI Element")] public GameObject countdown;

    private bool firstActionCard;

    void Start()
    {
        if (instance == null) instance = this;

        firstActionCard = true;
    }

    public void OnPressedA()
    {
        if (GameCard.instance.GetSolution() == 'a')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();
    }

    public void OnPressedB()
    {
        if (GameCard.instance.GetSolution() == 'b')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();
    }

    public void OnPressedC()
    {
        if (GameCard.instance.GetSolution() == 'c')
            ProcessRightSolution();
        else
            UI.instance.ShowWrongAnswerScreen();
    }

    /// <summary>
    /// A ActionCard was drawn. The right Solution is load in the SolutionPanel and the GateEditor will open.
    /// In this Case the GratulationPanel ends the turn.
    /// </summary>
    public void StartAction()
    {
        countdown.GetComponent<CountdownScript>().StartCountdown(240); //Start Countdown

        gateEditor.GetComponent<GateEditorManager>().ShowUp();
        gameObject.SetActive(false);

        if (firstActionCard) //At the first Time, the ReminderScreen shown up
        {
            firstActionCard = false;
            UI.instance.ShowReminderScreen();
        }

        int index = ActionCard.FindSolutionIndex() - 1; //-1, because Index should start at 0 
        //set the right logicalFormula in the TaskImage at the GateEditor
        var taskToShow = CardManager.instance.taskSet[index]; 
        task.GetComponent<Image>().sprite = CardManager.instance.TexToSprite(taskToShow.tex); 

        solutionPanel.GetComponent<SolutionPanel>().LoadSolution(index);
    }

    /// <summary>
    /// Called after a Answer is given or after the GateEditr closes.
    /// Resets the Countdown, Closes the ScreenCard and starts a NewTurn.
    /// </summary>
    public void EndTurn()
    {
        countdown.GetComponent<CountdownScript>().StopCountdown();
        gameObject.SetActive(false);
        GameManager.instance.NewTurn();
    }

    /// <summary>
    /// Called by the countdown when the time is over. 
    /// When the TimeOverScreen is closed, it will call EndTurn()
    /// </summary>
    public void TimeOver()
    {
        UI.instance.ShowTimeOverScreen();
    }

    /// <summary>
    /// starts the process, when the right answer is clicked
    /// </summary>
    private void ProcessRightSolution()
    {
        Score.instance.SetPointsRightAnswer();
        UI.instance.ShowRightAnswerScreen();

        if (GameManager.instance.GameFinishedRecord())
        {
            GameManager.instance.gameInProgress = false;
            UI.instance.ShowWinScreen();
        }
    }
}
