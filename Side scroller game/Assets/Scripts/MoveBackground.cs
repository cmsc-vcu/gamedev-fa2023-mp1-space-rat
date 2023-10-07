using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private GameObject background;
    public float horizontalMovement = -0.1f;
    private Rigidbody2D rb;
    Vector2 change;
    private float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        change = new Vector2(horizontalMovement, 0);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + change * speed * Time.fixedDeltaTime);
        }        
    }
}
