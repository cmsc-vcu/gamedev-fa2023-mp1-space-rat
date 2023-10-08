using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    private int score;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //score = player.GetComponent<PlayerInput>().scoreNum;
        score = PlayerInput.scoreNum;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + score.ToString();
        if (Input.anyKey)
        {
            PlayerInput.scoreNum = 0;
            StartCoroutine(Wait());
        }
    }
}
