using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotColdBar : MonoBehaviour
{
    public float secondsUntilStart = 210f;
    public GameObject player;
    public Sprite cold;
    public Sprite hot;

    private static GameObject matzah;
    private static bool active = false;
    private Image hotCold;
    private CanvasGroup cg;
    private RectTransform rt;

    void Start()
    {
        hotCold = GetComponent<Image>();
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        // wait until the matzah is chosen and received
        if (active)
        {
            // wait 3.5 mins to start showing images
            if (secondsUntilStart > 0)
            {
                secondsUntilStart -= Time.deltaTime;
            }
            else
            {
                cg.alpha = 1;

                float dist = Vector3.Distance(player.transform.position, matzah.transform.position);
                Debug.Log(dist);

                if (dist >= 2f)
                {
                    if (dist > 8f)
                    {
                        dist = 8f;
                    }

                    hotCold.sprite = cold;
                    float length = dist * 37.5f;
                    rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, length);
                    rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, length);
                }
                else
                {
                    if (dist < .5f)
                    {
                        dist = .5f;
                    }
                    float length = (1 / dist) * 200;

                    hotCold.sprite = hot;
                    rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, length);
                    rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, length);

                }
            }
        }
    }

    public static void receiveMatzah(GameObject m)
    {
        matzah = m;
        active = true;
    }
}
