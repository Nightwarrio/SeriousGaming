using UnityEngine;

/// <summary>
/// This Class manages the Audio 
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Tooltip("BackgroundMusic Data")] public GameObject backgroundMusic;
    [Tooltip("GateEditorMusic Data")] public GameObject gateEditorMusic;
    [Tooltip("StartMenuMusic Data")] public GameObject startMenuMusic;

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
