using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class InteractiveHUD : MonoBehaviour {
	//[SerializeField]private TextMeshProUGUI _interactiveText;
	[SerializeField]private Text _interactiveText;

	public Text timerText;
	public Text scoreText;
	void Update()
	{
		UpdateTimerUI();
	}
	//call this on update
	public void UpdateTimerUI()
	{
		//set timer UI
		if (ApplicationModel.findAll)
		{
			ApplicationModel.secondsCount -= Time.deltaTime;
            if (ApplicationModel.secondsCount <= 0)
			{
                if (ApplicationModel.minuteCount > 0)
				{
					ApplicationModel.minuteCount--;
					ApplicationModel.secondsCount = 59;
				}
                else
                {
					SceneManager.LoadScene("Winner");
                }
			}
			timerText.text = "Time: " + ApplicationModel.minuteCount.ToString("00") + ":" + ((int)ApplicationModel.secondsCount).ToString("00") + "";
			scoreText.text = "Score: " + ApplicationModel.score.ToString();
		}
		else
		{
			ApplicationModel.secondsCount += Time.deltaTime;
			timerText.text = "Time: " + ApplicationModel.minuteCount.ToString("00") + ":" + ((int)ApplicationModel.secondsCount).ToString("00") + "";
			if (ApplicationModel.secondsCount >= 60)
			{
				ApplicationModel.minuteCount++;
				ApplicationModel.secondsCount = 0;
			}
			else if (ApplicationModel.minuteCount >= 60)
			{
				ApplicationModel.minuteCount = 0;
			}
		}
	}
	public void SetInteractionText(string text)
	{
		if(_interactiveText)
		{
			if(text==null)
			{
				//_interactiveText.SetText("");
				_interactiveText.text = "";
				_interactiveText.gameObject.SetActive(false);
			}
			else
			{
				//_interactiveText.SetText(text);
				_interactiveText.text = text;
				_interactiveText.gameObject.SetActive(true);
			}
		}
	}	
}
