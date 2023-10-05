using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D player;
    private Vector3 offset = new Vector3 (5, 2, -20);

    void Start()
    { 

    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }
}
