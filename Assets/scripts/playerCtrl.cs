using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerCtrl : MonoBehaviour
{
    public ParticleSystem dust;
    public AudioSource pickSound;
    public AudioSource enemySound;


    public Text scoretext;

    public float forwardspeed, horizontalspeed;
    public Rigidbody rb;
    float horizontalinput;

    private int stopMulti = 1;

    private int scoreCollected = 0;


    Animator anim;

    public GameObject tryAgainButton;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("pickupitem"))
        {
            scoreCollected++;

            pickSound.Play();


            Destroy(collision.gameObject);
            //print(scoreCollected);
        }
        if (collision.CompareTag("enemy"))
        {
            scoreCollected--;

            enemySound.Play();
            //print(scoreCollected);

            if (scoreCollected >= 0)
            {
                Destroy(collision.gameObject);

            }


        }
        if (collision.CompareTag("endPoint"))
        {
            SceneManager.LoadScene("win");
        }

        scoretext.text = "Score: " + scoreCollected; 
    }


    private void FixedUpdate()
    {
        
        Vector3 forwardMove = transform.forward * forwardspeed * Time.fixedDeltaTime * stopMulti;
        Vector3 horizontalMove = transform.right * horizontalinput * horizontalspeed * Time.fixedDeltaTime * stopMulti;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Start is called before the first frame update
    void Start()
    {
        dust.Play();

        rb = GetComponent<Rigidbody>();

        tryAgainButton.SetActive(false);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalinput = Input.GetAxis("Horizontal");

        if (scoreCollected < 0)
        {
            anim.SetBool("death", true);
            stopMulti = 0;
        }

        if (anim.GetBool("death"))
        {
            tryAgainButton.SetActive(true);
            dust.Stop();

        }

    }

}
