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
    private float horizontalMovement = -0.3f;
    public float speed = 20.0f;
    public Rigidbody2D player;
    public int testVariable = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.tag = "Coin";
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }
}
