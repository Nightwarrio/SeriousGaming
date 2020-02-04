using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public GameObject countdownText;
    public GameObject screenCard;

  private float timer;
  private bool canCount = false;
  private bool doOnce = true;

    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            countdownText.GetComponent<Text>().text = timer.ToString("F");
        }
        else if(timer <= 0.0f && !doOnce)
        {
            StopCountdown();
            screenCard.GetComponent<ScreenCard>().TimeOver();
        }
    }

    /// <summary>
    /// Called by drawing a Card. Starts the countdown.
    /// </summary>
    public void StartCountdown(int timeInSeconds)
    {
        timer = timeInSeconds;
        canCount = true;
        doOnce = false;
    }

    public void StopCountdown()
    {
        canCount = false;
        doOnce = true;
        countdownText.GetComponent<Text>().text = "00.00";
        timer = 0.0f;
    }
}
