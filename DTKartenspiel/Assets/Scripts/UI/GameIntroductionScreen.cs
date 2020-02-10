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
            //TODO:: transform.getChild(i) benennen. Nicht nachvollziehbar, was das sein soll
            if (transform.GetChild(i).gameObject.name.Equals("Introduction_FirstPage") 
                && transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(i + 1).gameObject.SetActive(true);
                break;
            }
            else if (transform.GetChild(i).gameObject.name.Equals("Introduction_GatterPage") 
                && transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(i + 1).gameObject.SetActive(true);
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
            var tmp = transform.GetChild(i + 1).gameObject; //TODO:: Bennenen: was ist das?

            if (transform.GetChild(i).gameObject.name.Equals("Introduction_FirstPage") && 
                tmp.name.Equals("Introduction_GatterPage") && transform.GetChild(i + 1).gameObject.activeSelf)
            {
                tmp.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
            else if (transform.GetChild(i).gameObject.name.Equals("Introduction_GatterPage")
                && tmp.name.Equals("Introduction_KeyBindings") && transform.GetChild(i + 1).gameObject.activeSelf)
            {
                tmp.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}
