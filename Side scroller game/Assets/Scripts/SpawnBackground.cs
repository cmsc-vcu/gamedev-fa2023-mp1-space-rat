using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBackground : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D player;
    public GameObject background;
    Queue<GameObject> bgObjectsArr = new Queue<GameObject>();
    private float bgsize;
    private Quaternion rotation;
    private float xoffset = 6.0f;
    private float ypos = 3.0f;
    private float zpos = -10.0f;

    void Start()
    {
        rotation = new Quaternion(0, 0, 0, 0);
        Vector3 bg1Position = new Vector3(player.transform.position.x, ypos, zpos);
        GameObject bg1 = Instantiate(background, bg1Position, rotation);
        bgObjectsArr.Enqueue(bg1);
        Renderer bg1Renderer = bg1.GetComponent<Renderer>();
        bgsize = bg1Renderer.bounds.size.x;

        Vector3 bg2Position = new Vector3(bgsize, ypos, zpos);
        GameObject bg2 = Instantiate(background, bg2Position, rotation);
        bgObjectsArr.Enqueue(bg2);

        Vector3 bg3Position = new Vector3(bgsize * 2, ypos, zpos);
        GameObject bg3 = Instantiate(background, bg3Position, rotation);
        bgObjectsArr.Enqueue(bg3);
    }

    void Update()
    {
        float viewport = cam.orthographicSize * cam.aspect;
        if (bgObjectsArr.Count > 0 && player.transform.position.x - viewport > bgObjectsArr.Peek().transform.position.x + xoffset)
        {
            Destroy(bgObjectsArr.Dequeue());
            float xpos = bgObjectsArr.Peek().transform.position.x + bgsize / 2 + xoffset;
            Vector3 newStarPosition = new Vector3(bgsize * 2, ypos, zpos);
            GameObject newStar = Instantiate(background, newStarPosition, rotation);
            bgObjectsArr.Enqueue(newStar);
        }
    }
}
