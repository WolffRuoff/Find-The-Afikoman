using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotColdBar : MonoBehaviour
{
    public float maxDist = 15f;
    public GameObject player;

    private static GameObject matzah;
    private static float secondsUntilStart = 210f;
    private static bool active = false;
    private Image hotCold;
    private Text text;
    private Color red = new Color(.55f, 0f, 0f, 1f);
    private Color blue = new Color(0f, 0f, .55f, 1f);

    void Start()
    {
        hotCold = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        text.gameObject.SetActive(false);
    }

    void Update()
    {
        hotCold.color = new Color(0, 0, 0, 0);

        // wait until the matzah is chosen
        if (active)
        {
            // wait to display the bar (time waited based on difficulty)
            secondsUntilStart -= Time.deltaTime;

            if (secondsUntilStart < 0)
            {
                text.gameObject.SetActive(true);

                // calculate the distance from the matzah
                float dist = Vector3.Distance(player.transform.position, matzah.transform.position) - .75f;
                // lerp the color of the bar and change the text based on the distance
                hotCold.color = Color.Lerp(red, blue, (dist / maxDist));
                text.text = (dist < .6f) ? "Hot" : "Cold";
            }
        }
    }

    public static void receiveMatzah(GameObject m, float seconds)
    {
        matzah = m;
        secondsUntilStart = seconds;
        active = true;
    }
}
