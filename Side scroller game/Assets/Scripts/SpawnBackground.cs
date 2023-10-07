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
    private float bgsize;
    private Quaternion rotation;
    public float xoffset = 6.0f;
    public float ypos = 3.0f;
    public float zpos = -10.0f;
    List<GameObject> bgObjects = new List<GameObject>();

    void Start()
    {
        rotation = new Quaternion(0, 0, 0, 0);
        Vector3 bg1Position = new Vector3(player.position.x, ypos, zpos);
        GameObject bg1 = Instantiate(background, bg1Position, rotation);
        bgObjects.Add(bg1);
        Renderer bg1Renderer = bg1.GetComponent<Renderer>();
        bgsize = bg1Renderer.bounds.size.x;

        Vector3 bg2Position = new Vector3(bgsize, ypos, zpos);
        GameObject bg2 = Instantiate(background, bg2Position, rotation);
        bgObjects.Add(bg2);

        Vector3 bg3Position = new Vector3(bgsize * 2, ypos, zpos);
        GameObject bg3 = Instantiate(background, bg3Position, rotation);
        bgObjects.Add(bg3);
    }

    void Update()
    {
        float viewport = cam.orthographicSize * cam.aspect;
        if (bgObjects.Count > 0 && player.position.x - viewport > bgObjects[0].transform.position.x + xoffset)
        {
            GameObject temp = bgObjects[0];
            bgObjects.RemoveAt(0);
            Destroy(temp);

            float xpos = bgObjects[bgObjects.Count - 1].transform.position.x + bgsize;
            Vector3 newStarPosition = new Vector3(xpos, ypos, zpos);
            GameObject newStar = Instantiate(background, newStarPosition, rotation);
            bgObjects.Add(newStar);
        }
    }
}
