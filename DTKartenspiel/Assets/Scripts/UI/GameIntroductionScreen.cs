/// <summary>
/// Manages the GameIntroductionScreen UI Element
/// </summary>
public class GameIntroductionScreen : Screen
{
    /// <summary>
    /// Show the Next Page of the Screen
    /// </summary>
    public void NextIntroPage()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var nextPage = transform.GetChild(i + 1);
            var currentPage = transform.GetChild(i);

            if (currentPage.gameObject.name.Equals("Introduction_FirstPage") 
                && currentPage.gameObject.activeSelf)
            {
                currentPage.gameObject.SetActive(false);
                nextPage.gameObject.SetActive(true);
                break;
            }
            else if (currentPage.gameObject.name.Equals("Introduction_GatterPage") 
                && currentPage.gameObject.activeSelf)
            {
                currentPage.gameObject.SetActive(false);
                nextPage.gameObject.SetActive(true);
                break;
            }

        }
    }

    /// <summary>
    /// Show the Previous Page of the Screen
    /// </summary>
    public void PrevIntroPage()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var currentPage = transform.GetChild(i + 1).gameObject;
            var previousPage = transform.GetChild(i).gameObject;

            if (previousPage.name.Equals("Introduction_FirstPage") && 
                currentPage.name.Equals("Introduction_GatterPage") && currentPage.gameObject.activeSelf)
            {
                currentPage.SetActive(false);
                previousPage.SetActive(true);
                break;
            }
            else if (previousPage.name.Equals("Introduction_GatterPage")
                && currentPage.name.Equals("Introduction_KeyBindings") && currentPage.activeSelf)
            {
                currentPage.SetActive(false);
                previousPage.SetActive(true);
                break;
            }
        }
    }
}
