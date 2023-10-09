using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D coin;
    private float verticalInput;
    public float speed = 20.0f;
    Vector2 change;
    public TMP_Text scoreText;
    public GameObject scoreTracker;
    public Camera cam;
    float screenHeight;
    public AudioSource audioSource;
    private Animator animator;
    public static int scoreNum = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Player";
        scoreText.text = "score: 0";
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + change * speed * Time.fixedDeltaTime);
    }
    

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Jump");
        change = new Vector2(0, verticalInput);

        if (Input.GetKeyDown("space"))
        {
            audioSource.Play(0);
        }

        if (verticalInput == 0)
        {
            animator.SetBool("isjump", true);
        }
        else 
        {
            animator.SetBool("isjump", false);
        }
       

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Renderer>().material.color = Color.clear;
            scoreNum++;
            scoreText.text = "score: " + scoreNum.ToString();
        }
    }
}
