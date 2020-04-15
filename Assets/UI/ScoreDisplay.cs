using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = false;
        timerText.text = "Your time was\n" + ApplicationModel.minuteCount + " minutes and " + ApplicationModel.secondsCount.ToString("n2") + " seconds!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
