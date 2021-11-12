using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showStar : MonoBehaviour
{
    public GameObject[] goldStar;
    public GameObject[] noStar;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public Animator animator;

    public static int level;
    public static bool first;
    public static bool second;
    public static bool third;

    // Start is called before the first frame update
    void Start()
    {
        goldStar[0].SetActive(false);
        goldStar[1].SetActive(false);
        goldStar[2].SetActive(false);
        noStar[0].SetActive(false);
        noStar[1].SetActive(false);
        noStar[2].SetActive(false);
        life4.SetActive(false);
        life5.SetActive(false);

        if (first) //if starhas been collected, player is rewarded with an extra life
        {
            goldStar[0].SetActive(true);
            animator.SetTrigger("heart");
            life3.SetActive(false);
            life4.SetActive(true);
            kill.life = 4;
        }

        if (!first && level > 0)
        {
            noStar[0].SetActive(true);
        }        
        
        if (second)
        {
            goldStar[1].SetActive(true);
            animator.SetTrigger("heart2");
            if (first)
            {
                life4.SetActive(false);
                life5.SetActive(true);
                kill.life = 5;
            }
            else
            {
                life3.SetActive(false);
                life4.SetActive(true);
                kill.life = 4;

            }

        }

        if (!second && level > 1) //player did not collect a star
        {
            noStar[1].SetActive(true);
        }        
        
        if (third && level > 2)
        {
            goldStar[2].SetActive(true);
        }

        if (!first && level > 2)
        {
            noStar[2].SetActive(true);
        }
    }

}
