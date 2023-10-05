using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D coin;
    private float verticalInput;
    public float speed = 20.0f;
    Vector2 change;
    public TMP_Text scoreText;
    public static int scoreNum = 0;
    public GameObject scoreTracker;
    public Camera cam;
    float screenHeight;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Player";
        scoreText.text = "score: 0";
        //Camera.main.orthographic = true;
    }

    
    void FixedUpdate()
    {
        if (rb.position.y <= cam.orthographicSize + 2.5)
        {
            rb.MovePosition(rb.position + change * speed * Time.fixedDeltaTime);
        }
    }
    

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        change = new Vector2(0, verticalInput);
        //Debug.Log(2 * cam.orthographicSize);
        //Debug.Log(rb.position.y);



    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.clear;
            scoreNum++;
            scoreText.text = "score: " + scoreNum.ToString();
        }
    }
}
