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

      // Start is called before the first frame update
    void Start()
    {
      timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
      if(timer >= 0.0f && canCount){
        timer -= Time.deltaTime;
        uiText.GetComponent<Text>().text = timer.ToString("F");
      }
      else if(timer <= 0.0f && !doOnce){
        canCount = false;
        doOnce = true;
        uiText.GetComponent<Text>().text = "0.00";
        timer = 0.0f;
      }
    }
// resets timer
    public void resetButton(){
      timer = mainTimer;
      canCount = true;
      doOnce = false;
      countdownScreen.SetActive(false);

    }

}
