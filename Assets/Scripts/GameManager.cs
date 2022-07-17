using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameOver gameOverScript;

    [Header("General")]
    [SerializeField] public int score;
    [SerializeField] private int health;
    [SerializeField] public int tileSpawnNo;
    [SerializeField] public int obstacleSpawnFrequency;     // Every x tiles spawn an obstacle/wall
    [SerializeField] TMP_Text Score;
    



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 3;
        tileSpawnNo = 0;
        obstacleSpawnFrequency = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + score.ToString("F0");
    }

    public void loseHealth() {
        health--;
        if (health <= 0)
            gameOverScript.EndGame(score);
    }

    public void EndGame() {
        gameOverScript.EndGame(score);
    }

}
