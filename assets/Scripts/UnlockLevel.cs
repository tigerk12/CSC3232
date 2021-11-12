using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public GameObject contruction1;
    public GameObject door;    
    public GameObject contruction2;
    public GameObject door2;

    public static int level;

    // Start is called before the first frame update
    void Start()
    {
        contruction1.SetActive(true);
        door.GetComponent<Collider2D>().enabled = false;
        contruction2.SetActive(true);
        door2.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update() //remove construction off the doors when previous level is completed
    {
        
        if(level > 0 )
        {
            contruction1.SetActive(false);
            door.GetComponent<Collider2D>().enabled = true;
        }

        if(level > 1) 
        {
            contruction2.SetActive(false);
            door2.GetComponent<Collider2D>().enabled = true;
        }
    }

}
