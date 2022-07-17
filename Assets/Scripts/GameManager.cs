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
    [SerializeField] float timer = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 3;
        tileSpawnNo = 0;

        InvokeRepeating("IncreaseScore", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // score += (int)(Time.deltaTime * 100);
        Score.text = "Score: " + score.ToString("F0");
    }

    public void LoseHealth() {
        health--;
        if (health <= 0)
            gameOverScript.EndGame(score);
    }

    public void EndGame() {
        gameOverScript.EndGame(score);
    }

    public float SetMoveSpeed() {
        return Mathf.Min(score / 100 + 1, 10);

    }

    void IncreaseScore() {
        score += 1;
    }

}
