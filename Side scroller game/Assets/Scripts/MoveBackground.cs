using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private GameObject background;
    public float horizontalMovement = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<GameObject>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
}
