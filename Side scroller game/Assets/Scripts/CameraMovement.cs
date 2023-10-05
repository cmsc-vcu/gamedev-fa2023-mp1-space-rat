using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector3 offset = new Vector3 (5, 2, -20);
    public GameObject stars;
    Queue<GameObject> stars_arr = new Queue<GameObject>();

    void Start()
    {
        /*
         * Goal: move background image along and loop 
         * Instantiate two instances of bg image 
         * For each update, move both instances to the left
         * Once the first one is out of the frame, add a new one after the second and delete the first
         * 
         * 
         */

        Vector3 star1_position = new Vector3(player.transform.position.x, 3, 1);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);

        GameObject star1 = Instantiate(stars, star1_position, rotation);
        stars_arr.Enqueue(star1);
        Renderer star1_renderer = star1.GetComponent<Renderer>();

        Vector3 star2_position = new Vector3(star1_renderer.bounds.size.x, 3, 1);
        GameObject star2 = Instantiate(stars, star2_position, rotation);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }
}
