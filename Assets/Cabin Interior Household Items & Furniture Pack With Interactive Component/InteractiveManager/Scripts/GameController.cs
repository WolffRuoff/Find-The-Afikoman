using MB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int matzahSurvivor = 0;
    private int matzahNumber;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] matzahs = GameObject.FindGameObjectsWithTag("Win");
        matzahNumber = matzahs.Length + 1;
        if (matzahSurvivor == 0)
        {
            matzahSurvivor = Random.Range(1,matzahNumber);
            Debug.Log(matzahSurvivor);
            Debug.Log(matzahNumber);
            foreach (GameObject i in matzahs)
            {
                int idCheck = i.GetComponent<InteractiveMatzah>().id;
                if(idCheck != matzahSurvivor)
                {
                    Destroy(i);
                } else
                {
                    HotColdBar.receiveMatzah(i);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
