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

        // wait until the matzah is chosen and received
        if (active)
        {
            secondsUntilStart -= Time.deltaTime;
            if (secondsUntilStart < 0)
            {
                text.gameObject.SetActive(true);
            }

            float dist = Vector3.Distance(player.transform.position, matzah.transform.position) - .75f;
            Debug.Log(dist);
            hotCold.color = (secondsUntilStart < 0) ? Color.Lerp(red, blue, (dist / maxDist)) : new Color(0, 0, 0, 0);

            if (dist < .6f)
            {
                text.text = "Hot";
            }
            else
            {
                text.text = "Cold";
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
