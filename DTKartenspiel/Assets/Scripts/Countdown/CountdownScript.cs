using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
  public GameObject uiText;
  public float mainTimer;
  public GameObject countdownScreen;

  private float timer;
  private bool canCount = false;
  private bool doOnce = true;
  private bool alreadyWrong = false;
  private GameObject gatter, card, wrongAnswer;

      // Start is called before the first frame update
    void Start()
    {
      timer = mainTimer;
      card = transform.Find("ScreenCard").gameObject;
      gatter = transform.Find("GatterEditor").gameObject;
      wrongAnswer = transform.Find("WrongAnswer").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
      if(timer >= 0.0f && canCount && !GetComponent<UI>().getAnswerGiven() && !alreadyWrong) {
        timer -= Time.deltaTime;
        uiText.GetComponent<Text>().text = timer.ToString("F");
      }
      else if(timer <= 0.0f && !doOnce){
        canCount = false;
        doOnce = true;
        uiText.GetComponent<Text>().text = "0.00";
        timer = 0.0f;
      }

      else if(timer == 0.0f && !alreadyWrong){  // new
        alreadyWrong = true;
        GetComponent<UI>().setanswerGivenTrue();
        wrongAnswer.SetActive(true);
        if(card.activeSelf == true){
          card.SetActive(false);
        }
        else if(gatter.activeSelf == true){
          gatter.SetActive(false);
        }

      }
    }

    /// new stuff
// resets timer
    public void resetButton(){
      timer = mainTimer;
      canCount = true;
      doOnce = false;
      countdownScreen.SetActive(false);
      alreadyWrong = false;
      GetComponent<UI>().setanswerGivenFalse();
      card.SetActive(true);
    }
    public bool getAlreadyWrong(){
      return alreadyWrong;
    }

    public void setAlreadyWrong(bool what){
      alreadyWrong = what;
    }

}
