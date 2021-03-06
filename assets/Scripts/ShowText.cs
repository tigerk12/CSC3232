using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    [SerializeField]
    private Text showText;

    private bool allowed;

    // Start is called before the first frame update
    void Start()
    {
        showText.gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showText.gameObject.SetActive(true);
            allowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showText.gameObject.SetActive(false);
            allowed = false;
        }
    }
}
