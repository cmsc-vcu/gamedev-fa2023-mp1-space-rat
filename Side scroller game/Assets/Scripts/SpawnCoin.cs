using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class SpawnCoin : MonoBehaviour
{
    public GameObject prefab;
    public Rigidbody2D player;
    public float interval = 3f;
    private float nextInterval = 0.0f;
    public Camera cam;
    Queue<GameObject> queue = new Queue<GameObject>(); //keeps track of clones
    Random random = new Random();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float viewport = cam.orthographicSize * cam.aspect;

        if (Time.time > nextInterval)
        {
            Vector3 position = new Vector3(player.transform.position.x + (float) 4.0 * viewport + random.Next(0, 2), (float)0.55 + random.Next(0, 4), 1);
            Quaternion rotation = new Quaternion(0, 0, 0, 0);
            GameObject clone = Instantiate(prefab, position, rotation);
            queue.Enqueue(clone);
            nextInterval = Time.time + interval;
        }

        if (queue.Count > 0 && player.transform.position.x - viewport > queue.Peek().transform.position.x)
        {
            Destroy(queue.Dequeue());
        }
    }
}
