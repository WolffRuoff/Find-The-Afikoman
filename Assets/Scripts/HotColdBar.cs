using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotColdBar : MonoBehaviour
{
    public static float flashTimer = 1.5f;
    public float maxDist = 15f;
    public GameObject player;

    private static GameObject matzah;
    private static float secondsUntilFlash;
    private static float secondsUntilFlashTimer;
    private static bool active = false;
    private Image hotCold;
    private Text text;
    private Color red = new Color(.55f, 0f, 0f, 1f);
    private Color blue = new Color(0f, 0f, .55f, 1f);

    private int currScore = -1;

    void Start()
    {
        hotCold = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {

        // wait until the matzah is chosen
        if (active && !ApplicationModel.findAll)
        {
            if (secondsUntilFlashTimer > 0)
            {
                // countdown until show
                secondsUntilFlashTimer -= Time.deltaTime;
                hotCold.color = Color.white;
                text.fontSize = 54;
                text.text = "Hot/Cold Powerup in: " + Mathf.Ceil(secondsUntilFlashTimer) + " seconds";
            }
            else
            {
                // show for 1 sec
                flashTimer -= Time.deltaTime;

                // calculate the distance, lerp the color and update the text
                float dist = Vector3.Distance(player.transform.position, matzah.transform.position) - .75f;
                hotCold.color = Color.Lerp(red, blue, (dist / maxDist));
                text.text = (dist < .6f) ? "Hot" : "Cold";
                text.fontSize = 115;

                // reset
                if (flashTimer < 0)
                {
                    secondsUntilFlashTimer = secondsUntilFlash;
                    flashTimer = 1.5f;
                }
            }
        }
        else if (ApplicationModel.findAll)
        {
            text.fontSize = 54;

            if (currScore != ApplicationModel.score)
            {
                currScore = ApplicationModel.score;
                text.text = "Afikomen Remaining: " + (ApplicationModel.matzahs.Length - currScore);

            }
        }
    }

    public static void receiveMatzah(GameObject m, float seconds)
    {
        matzah = m;
        secondsUntilFlashTimer = seconds;
        secondsUntilFlash = seconds;
        active = true;
    }
}
