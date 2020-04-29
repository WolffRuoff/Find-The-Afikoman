using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Canvas loadingScreenObj;
    public Slider slider;
    public GameObject playButton;

    AsyncOperation async;

 
    public void LoadScreenExample()
    {
        StartCoroutine(LoadingScreenControl());
    }

    IEnumerator LoadingScreenControl()
    {
        loadingScreenObj.enabled = true;
        playButton.SetActive(false);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                //playButton.SetActive(true);
                async.allowSceneActivation = true;
            }
            yield return null;

        }
    }

    public void Activate()
    {
        async.allowSceneActivation = true;
    }

    public void Disable()
    {
        loadingScreenObj.enabled = false;
    }
    public void Enable()
    {
        loadingScreenObj.enabled = true;
    }
}