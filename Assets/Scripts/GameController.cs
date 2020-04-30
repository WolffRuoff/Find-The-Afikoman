using MB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public int matzahSurvivor = 0;
    private int matzahNumber;
    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationModel.findAll)
        {
            ApplicationModel.minuteCount = 1;
            ApplicationModel.score = 0;
            GameObject[] easyM = GameObject.FindGameObjectsWithTag("Easy");
            GameObject[] hardM = GameObject.FindGameObjectsWithTag("Hard");
            easyM = easyM.Concat(hardM).ToArray();
            ApplicationModel.matzahs = easyM;
            //if Game Mode is findAll, randomly destory 3 matzahs, leave the rest
            for (int i=0; i<3; i++)
            {
                matzahNumber = ApplicationModel.matzahs.Length + 1;
                int d = Random.Range(1, matzahNumber);
                Destroy(ApplicationModel.matzahs[d]);
                var m = new List<GameObject>(ApplicationModel.matzahs);
                m.RemoveAt(d);
                ApplicationModel.matzahs= m.ToArray();
            }
        }
        else
        {
            //if Game Mode is not findAll, randomly save 1 matzah, destroy the rest
            GameObject.FindGameObjectWithTag("Score").SetActive(false);
            if (matzahSurvivor == 0)
            {
                string cTag;
                string noTag;

                if (ApplicationModel.difficulty == 0)
                {
                    cTag = "Easy";
                    noTag = "Hard";
                }
                else
                {
                    cTag = "Hard";
                    noTag = "Easy";
                }
                GameObject[] matzahs = GameObject.FindGameObjectsWithTag(cTag); //Difficulty selected
                matzahNumber = matzahs.Length + 1;
                GameObject[] notzahs = GameObject.FindGameObjectsWithTag(noTag); //Difficulty Not selected
                foreach (GameObject i in notzahs) //removes all of the wrong difficulty's matzah
                    Destroy(i);

                matzahSurvivor = Random.Range(1, matzahNumber);
                //Debug.Log(matzahSurvivor);
                //Debug.Log(matzahNumber);
                foreach (GameObject i in matzahs)
                {
                    int idCheck = i.GetComponent<InteractiveMatzah>().id;
                    if (idCheck != matzahSurvivor)
                    {
                        Destroy(i);
                    }
                    else
                    {
                        float seconds = (ApplicationModel.difficulty == 0) ? 20 : 45;
                        HotColdBar.receiveMatzah(i, seconds);
                    }
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
