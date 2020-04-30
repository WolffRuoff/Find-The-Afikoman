using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class WinMenu : MonoBehaviour
{
    public Canvas winStuff;

    public GameObject playButton;

    public AudioSource audioS;
    public GameObject loadingScreen;
    private void Start()
    {
        loadingScreen.GetComponent<LoadingScreen>().Disable();
        StartCoroutine(AudioController.FadeIn(audioS, 3f));
    }

    // function that is assigned to clicking the buttons on the main menu
    public void LoadLevel(int level)
    {
        if (level == 1)
        {
            ApplicationModel.secondsCount = 0;
            ApplicationModel.minuteCount = 0;
            ApplicationModel.hourCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (level == 2)
        {
            ApplicationModel.secondsCount = 0;
            ApplicationModel.minuteCount = 0;
            ApplicationModel.hourCount = 0;

            winStuff.enabled = false;
            loadingScreen.GetComponent<LoadingScreen>().Enable();
            loadingScreen.GetComponent<LoadingScreen>().LoadScreenExample();

            StartCoroutine(AudioController.FadeOut(audioS, 1f));
            //SceneManager.LoadScene("Demo");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            SceneManager.LoadScene("Demo");
        }
    }
}
