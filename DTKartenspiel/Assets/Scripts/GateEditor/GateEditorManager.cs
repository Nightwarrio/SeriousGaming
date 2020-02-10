using UnityEngine;

/// <summary>
/// The Class for the GateEditor. 
/// </summary>
public class GateEditorManager : MonoBehaviour
{
    public static GateEditorManager instance;

    [Tooltip("The GratulationPanel")] public GameObject gratulationPanel;
    [Tooltip("The ChooseEntry Screen")] public GameObject chooseEntry;
    [Tooltip("The Points UI Element")] public GameObject points;
    [Tooltip("Prefab for the Fading PointsNumber")] public GameObject pointsNumber;
    [Tooltip("Prefab for the Fading False")] public GameObject falsePrefab;
    [Tooltip("Textures of all Logical Gates")] public Texture2D[] gateTextures;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    /// <summary>
    /// Called by the GratulationPanel an the GiveUp-Button.
    /// Make all Preparartions to leave the GateEditor and go back to Game.
    /// </summary>
    public void BackToGame()
    {
        gameObject.SetActive(false);
        gratulationPanel.SetActive(false);
        chooseEntry.SetActive(false);

        CraftingPanel.instance.ClearPanel();
        points.GetComponent<Points>().Reset();

        ScreenCard.instance.EndTurn();
        AudioManager.instance.PlayBackgroundMusic();
    }

    /// <summary>
    /// If a Gate is right positioned, the Placeholder call this Method.
    /// The Points are shown up and will be set on the Scoreboard.
    /// </summary>
    /// <param name="placeToSpawn">The right positioned Gate</param>
    public void ShowPoints(GameObject placeToSpawn)
    {
        var fadingPoints = Instantiate(pointsNumber, placeToSpawn.transform.position, placeToSpawn.transform.rotation);
        fadingPoints.transform.SetParent(placeToSpawn.transform);

        points.GetComponent<Points>().SetText();
        Score.instance.SetPointsRightGate();
    }

    /// <summary>
    /// Is shown when a not correct placed Gate has dropped
    /// </summary>
    public void ShowFalse(GameObject placeToSpawn)
    {
        var fadingFalse = Instantiate(falsePrefab, placeToSpawn.transform.position, placeToSpawn.transform.rotation);
        fadingFalse.transform.SetParent(placeToSpawn.transform);
    }

    /// <summary>
    /// Set the GateEditor active and play the Music
    /// </summary>
    public void ShowUp()
    {
        gameObject.SetActive(true);
        AudioManager.instance.PlayGateEditorMusic();
    }
}
