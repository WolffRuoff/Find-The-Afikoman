using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MainMenu : MonoBehaviour
{
    public Canvas title;
    public Canvas howToPlay;
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    private GameObject[] slides;

    public GameObject playButton;
    public GameObject nextButton;

    public AudioSource audioS;
    private void Start()
    {
        howToPlay.enabled = false;
        slides = new GameObject[] { slide1, slide2, slide3, slide4 };
        foreach(GameObject slide in slides)
        {
            slide.SetActive(false);
        }
        StartCoroutine(AudioController.FadeIn(audioS, 3f));
    }

    // function that is assigned to clicking the buttons on the main menu
    public void LoadLevel(int level)
    {
        if (level == 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (level == 1)
        {
            StartCoroutine(AudioController.FadeOut(audioS, 1f));
            SceneManager.LoadScene("Demo");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else if (level == 3)
        {
            if (slide1.activeSelf)
            {
                title.enabled = true;
                howToPlay.enabled = false;
            }
            else if(slides[slides.Length-1].activeSelf)
            {
                playButton.SetActive(false);
                nextButton.SetActive(true);
                CallPrevSlide();
            }
            else
            {
                CallPrevSlide();
            }
        }
        else if (level == 4)
        {
            if (slides[slides.Length-2].activeSelf)
            {
                playButton.SetActive(true);
                nextButton.SetActive(false);
            }
            CallNextSlide();
        }
        else if(level == 5)
        {
            title.enabled = false;
            howToPlay.enabled = true;
            slide1.SetActive(true);
            playButton.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    private void CallPrevSlide()
    {
        int prevSlideIndex;
        foreach(GameObject slide in slides)
        {
            if (slide.activeSelf)
            {
                prevSlideIndex = Array.IndexOf(slides, slide)-1;
                slide.SetActive(false);
                slides[prevSlideIndex].SetActive(true);
                break;
            }
        }
    }
    private void CallNextSlide()
    {
        int nextSlideIndex;
        foreach (GameObject slide in slides)
        {
            if (slide.activeSelf)
            {
                nextSlideIndex = Array.IndexOf(slides, slide) + 1;
                slide.SetActive(false);
                slides[nextSlideIndex].SetActive(true);
                break;
            }
        }
    }
}
