using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PickupCoin : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMovement = -0.25f;
    public float speed = 20.0f;
    public Rigidbody2D player;
    public int testVariable = 0;
    private float interval = 10.0f;
    private float time;
    private float speedIncrease = -0.01f;
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.tag = "Coin";
        time = interval;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= time)
        {
            horizontalMovement += speedIncrease;
            time += interval;
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play(0);
        }
    }

}
