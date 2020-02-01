using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    private GameObject[] arrayOfChildren;
    private GameObject[] playerField = new GameObject[4];
    private GameObject startWindow, playerSelect, playerButton, cancelButton, currentPlayer, textField;
    private int[] players = new int[4];
    private int countImportantChildren = 0;
    private int allActivated = 0;
    private bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {

        arrayOfChildren = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            arrayOfChildren[i] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < arrayOfChildren.Length; i++) {
            if (arrayOfChildren[i].name == "StartGame")
            {
                startWindow = arrayOfChildren[i];
            }
            else if (arrayOfChildren[i].name == "PlayerSelect") {
                playerSelect = arrayOfChildren[i];
                for (int a = 0; a < playerSelect.transform.childCount; a++)
                {
                    if (playerSelect.transform.GetChild(a).gameObject.tag == "Player")
                    {
                        playerField[countImportantChildren] = playerSelect.transform.GetChild(a).gameObject;
                        countImportantChildren += 1;

                    }
                }
                }

            }
        }



    // Update is called once per frame
    void Update()
    {
        if (playerSelect.activeSelf == true) {
            foreach (var GameObject in playerField)
            {

            }
        }

    }

    public void SelectPlayerWindow() {
            startWindow.SetActive(false);
            playerSelect.SetActive(true);
    }

    public void playerWasSelected()
    {
        for (int i = 0; i < playerField.Length; i++) {
          if(EventSystem.current.currentSelectedGameObject.tag[EventSystem.current.currentSelectedGameObject.tag.Length-1] == playerField[i].name[playerField[i].name.Length-1]){
            currentPlayer = playerField[i];
            break;
          }
        }
          playerButton = currentPlayer.transform.Find("PlayerButton").gameObject;
          cancelButton = currentPlayer.transform.Find("CancelButton").gameObject;
          textField = currentPlayer.transform.Find("InputField").gameObject;
          if(playerButton.activeSelf == true){
            playerButton.SetActive(false);
            cancelButton.SetActive(true);
            textField.GetComponent<InputField>().enabled = false;
            allActivated += 1;
          }
          else if(cancelButton.activeSelf == true){
            cancelButton.SetActive(false);
            playerButton.SetActive(true);
            textField.GetComponent<InputField>().enabled = true;
            allActivated -= 1;
          }
    }



    public void startGameButton() {
      if(allActivated % 2 == 0)
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
      else{
          this.transform.Find("UnableToStart").gameObject.SetActive(true);
      }
    }
    public void unableToStartButton(){
      this.transform.Find("UnableToStart").gameObject.SetActive(false);
    }
}
