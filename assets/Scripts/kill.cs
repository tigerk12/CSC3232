using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class kill : MonoBehaviour
{
    [SerializeField]
    private TMP_Text showText;

    private Rigidbody2D rb;
    public Animator animator;
    public GameObject game_object;
    public GameObject camera;
    public GameObject[] Hearts;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public GameObject canvas;
    public Color colour = Color.red;
    private player_movement Pm;
    public static int life = 3;

    public static bool bossFight = false;
    bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        Pm = game_object.GetComponent<player_movement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        showText.gameObject.SetActive(false);
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Hearts[3].gameObject.SetActive(false);
        Hearts[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(life > 4) //extra life
        {
            Hearts[3].gameObject.SetActive(true);
        }
        if (life == 5)
        {
            Hearts[4].gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && UnlockLevel.level < 2)
        {
            dead();
        }
        else if (collision.gameObject.tag == "Enemy" && UnlockLevel.level == 2)
        {
            bossDead();
        }

    }

    void dead () //death when level < 3
    {
        if (!isDead && life > 1) //when killed, player movement is disabled and player is respawned 3 seconds later
        {
            isDead = true;
            life = life - 1;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            animator.SetBool("isJumping", false);
            animator.SetBool("isDead", true);
            transform.Rotate(0.0f, 0f, 90f);
            Pm.enabled = false;
            rb.gravityScale = -1f;

            camera.GetComponent<CameraController>().Clamp();

            Destroy(Hearts[life].gameObject);

            StartCoroutine(Respawn());

        }
        else if(!isDead && life == 1)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            animator.SetBool("isJumping", false);
            animator.SetBool("isDead", true);
            transform.Rotate(0.0f, 0f, 90f);
            Pm.enabled = false;
            rb.gravityScale = -1f;

            showText.gameObject.SetActive(true);
            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);

            camera.GetComponent<CameraController>().Clamp();


            BG1.GetComponent<Renderer>().material.color = colour;
            BG2.GetComponent<Renderer>().material.color = colour;

            Destroy(Hearts[life].gameObject);

        }

    }

    void bossDead() //death on level 3
    {
        if (!isDead && life > 1)
        {
            isDead = true;
            life = life - 1;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            animator.SetBool("isJumping", false);
            animator.SetBool("isDead", true);
            transform.Rotate(0.0f, 0f, 90f);
            Pm.enabled = false;
            rb.gravityScale = -1f;

            camera.GetComponent<autoCam>().Clamp();

            Destroy(Hearts[life].gameObject);

            StartCoroutine(bossRespawn());
        }

        else if (!isDead && life == 1)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            animator.SetBool("isJumping", false);
            animator.SetBool("isDead", true);
            transform.Rotate(0.0f, 0f, 90f);
            Pm.enabled = false;
            rb.gravityScale = -1f;

            showText.gameObject.SetActive(true);
            Button1.gameObject.SetActive(true);
            Button2.gameObject.SetActive(true);

            camera.GetComponent<autoCam>().Clamp();

            Destroy(Hearts[life].gameObject);

        }

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        this.transform.position = spawnPoint.transform.position;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        camera.GetComponent<CameraController>().unClamp();

        animator.SetBool("isDead", false);
        transform.Rotate(0.0f, 0f, -90f);
        Pm.enabled = true;
        rb.gravityScale = 9.8f;
        isDead = false;
    }

    IEnumerator bossRespawn()
    {
        if (!bossFight)
        {
            yield return new WaitForSeconds(3);
            this.transform.position = spawnPoint.transform.position;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
            camera.GetComponent<autoCam>().unClamp();

            animator.SetBool("isDead", false);
            transform.Rotate(0.0f, 0f, -90f);
            Pm.enabled = true;
            rb.gravityScale = 9.8f;
            isDead = false;
        }

        if (bossFight) // change spawnpoint to boss area
        {
            yield return new WaitForSeconds(3);
            this.transform.position = spawnPoint2.transform.position;
            GetComponent<Collider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
            camera.GetComponent<autoCam>().unClamp();

            animator.SetBool("isDead", false);
            transform.Rotate(0.0f, 0f, -90f);
            Pm.enabled = true;
            rb.gravityScale = 9.8f;
            isDead = false;
        }
    }

}
