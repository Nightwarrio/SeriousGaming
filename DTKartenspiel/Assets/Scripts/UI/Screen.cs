using UnityEngine;

/// <summary>
/// Base Class of all Screens
/// </summary>
public abstract class Screen : MonoBehaviour
{
    /// <summary>
    /// Closes the open Panel
    /// </summary>
    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
        if(CardStack.instance.GetCardCount() == 0){
          GameManager.instance.EndGame();
        }
    }

    /// <summary>
    /// Opens the Panel
    /// </summary>
    public virtual void ShowScreen()
    {
        gameObject.SetActive(true);
    }
}
