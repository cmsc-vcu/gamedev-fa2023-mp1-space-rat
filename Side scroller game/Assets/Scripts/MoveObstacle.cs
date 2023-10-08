using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObstacle : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private float horizontalMovement = -0.25f; //speed of obstacles 
    public float speed = 20.0f;
    Vector2 change;
    public Rigidbody2D player;
    public AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.AddComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (gameObject.name == "Fire")
        {
            animator.Play("Fire Animation");
        }
        
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play(0);
            StartCoroutine(Wait());
        }
    }
}
