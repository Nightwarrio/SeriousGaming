using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject backgroundMusic;
    public GameObject gateEditorMusic;
    public GameObject startMenuMusic;

    void Start()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);

        startMenuMusic.GetComponent<AudioSource>().enabled = true;
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusic.GetComponent<AudioSource>().enabled = true;
        gateEditorMusic.GetComponent<AudioSource>().enabled = false;
        startMenuMusic.GetComponent<AudioSource>().enabled = false;
    }

    public void PlayGateEditorMusic()
    {
        backgroundMusic.GetComponent<AudioSource>().enabled = false;
        gateEditorMusic.GetComponent<AudioSource>().enabled = true;
    }

    public void StopMusic()
    {
        backgroundMusic.GetComponent<AudioSource>().enabled = false;
        gateEditorMusic.GetComponent<AudioSource>().enabled = false;
        startMenuMusic.GetComponent<AudioSource>().enabled = false;
    }
}
