using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMovement = -0.3f; //speed of obstacles 
    public float speed = 20.0f;
    Vector2 change;
    public Rigidbody2D player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //gameObject.tag = "Obstacle";
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }      
    }
}
