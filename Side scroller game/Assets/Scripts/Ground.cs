using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Rigidbody2D player;
    private Rigidbody2D ground;
    private Vector2 offset = new Vector2(10, 0);

    void Start()
    {  
        ground = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector3(100 * player.transform.position.x, (float)0.1, (float)1);
        //ground.MovePosition(player.position + new Vector2(-2, 0));
        //transform.position = new Vector2(player.transform.position.x + offset.x, offset.y);

    }
}
