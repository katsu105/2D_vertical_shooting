using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE:" + score;
        
    }
    private void Update()
    {
        if (gameOverText.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            }
        }
        
    }

    // Update is called once per frame
    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
