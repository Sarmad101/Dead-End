using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce , playerSpeed , PositionRadius;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public LayerMask ground;
    public Transform playerPos;

    public Text Timme, Scores;
    private int seconds = 0, minutes = 0;
    float sc;
    public float score = 0f;
    public Slider hp;
    public float hp_Value;

    bool overGame = false;
    public Text score_High;
    public GameObject GameOver;

    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for(int i=0; i < colliders.Length; i++)
        {
            for(int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
        if (PlayerPrefs.HasKey("score"))
        {
            score_High.text = "Highest Score : " + PlayerPrefs.GetFloat("score");
        }
        else
        {
            score_High.text = "Highest Score : 0";
        }
     }

    
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("walk");
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
            else
            {
                anim.Play("walkback");
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            anim.Play("movement");
        }

        isOnGround = Physics2D.OverlapCircle(playerPos.position, PositionRadius, ground);
        if(isOnGround==true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            this.gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
        
    }
    void LateUpdate()
    {
        sc += 1.0f * Time.deltaTime;
        seconds = (int)sc;
        if (seconds > 59)
        {
            minutes = seconds;
            seconds = 0;

        }
        Timme.text = "Time :- " + minutes.ToString() + " : " + seconds.ToString();
        Scores.text = "Score : " + score.ToString();
        if (hp_Value > 0f)
        {
            hp.value = hp_Value;
        }
        if (hp_Value <= 0)
        {
            overGame = true;
            GameOver.SetActive(true);
        }

        if (overGame)
        {
            if (PlayerPrefs.HasKey("score"))
            {
                if (PlayerPrefs.GetFloat("score") < score)
                {
                    PlayerPrefs.SetFloat("score", score);
                }
            }
            else
            {
                PlayerPrefs.SetFloat("score", score);
            }

            overGame = false;
        }
    }
}
