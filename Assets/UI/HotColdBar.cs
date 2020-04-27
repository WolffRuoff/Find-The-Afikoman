using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotColdBar : MonoBehaviour
{
    public float secondsUntilStart = 210f;
    public float maxDist = 15f;
    public GameObject player;

    private static GameObject matzah;
    private static bool active = false;
    private Image hotCold;
    private Color red = new Color(.55f, 0f, 0f, 1f);
    private Color blue = new Color(0f, 0f, .55f, 1f);

    void Start()
    {
        hotCold = GetComponent<Image>();
    }

    void Update()
    {
        // wait until the matzah is chosen and received
        if (active)
        {
            secondsUntilStart -= Time.deltaTime;
            float dist = Vector3.Distance(player.transform.position, matzah.transform.position) - .75f;
            Debug.Log(dist);
            hotCold.color = (secondsUntilStart < 0) ? Color.Lerp(red, blue, (dist / maxDist)) : new Color(0, 0, 0, 0);
        }
    }

    public static void receiveMatzah(GameObject m)
    {
        matzah = m;
        active = true;
    }
}
