using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    public Transform grabDetect;
    public Transform boxHolder;
    public Transform placement;
    public GameObject game_object;
    public GameObject star;
    private player_movement Pm;
    private float raydDist;
    bool grab;

    private void Start()
    {
        Pm = game_object.GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, raydDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Spring")
        {

            if (Input.GetKey(KeyCode.E)) //hold spring
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grab = true;
                Pm.Holding();
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
            }

        }

        if (grab) //drop held objects
        {
            if (Input.GetKey(KeyCode.F))
            {
                boxHolder.gameObject.transform.parent = null;
                boxHolder.gameObject.transform.position = placement.position;
                grab = false;
                Pm.Dropped();
            }
        }



        if (grabCheck.collider != null && grabCheck.collider.tag == "Block")
        {

            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grab = true;
                Pm.Gravity(); //player becomes heavier
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
            }

        }

        if (grab)
        {
            if (Input.GetKey(KeyCode.F))
            {
                boxHolder.gameObject.transform.parent = null;
                boxHolder.gameObject.transform.position = placement.position;
                grab = false;
                Pm.Dropped();
            }
        }

        if (grabCheck.collider != null && grabCheck.collider.tag == "Star") //pick up stars
        {
            star.SetActive(false);
            if(showStar.level == 0)
            {
                showStar.first = true;
            }
            if (showStar.level == 1)
            {
                showStar.second = true;
            }
            if (showStar.level == 2)
            {
                showStar.third = true;
            }

        }

    }

}
