using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameOver gameOverScript;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private AudioManager audioManagerScript;
    [SerializeField] private AudioClip wallCrash;
    [SerializeField] private AudioClip hurtSound;

    [Header("General")]
    [SerializeField] public int score;
    [SerializeField] private int health;
    [SerializeField] public int tileSpawnNo;
    [SerializeField] public int tileSpawnLimit = 8;
    [SerializeField] public int obstacleSpawnFrequency;     // Every x tiles spawn an obstacle/wall
    [SerializeField] private int moveSpeedScaler = 100;
    [SerializeField] private int baseMoveSpeed = 10;
    [SerializeField] private int maxMoveSpeed = 25;
    [SerializeField] TMP_Text Score;
    

    // Start is called before the first frame update
    void Start()
    {
        audioManagerScript = GameObject.Find("WallNoise").GetComponent<AudioManager>();
        score = 0;
        health = 3;
        tileSpawnNo = 0;

        InvokeRepeating("IncreaseScore", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + score.ToString("F0");
        // print(GetMoveSpeed());
    }

    public void LoseHealth() {
        health--;
        hearts[health].SetActive(false);
        if (health <= 0)
            gameOverScript.EndGame(score);
    }

    public void EndGame() {
        hearts[0].SetActive(false);
        hearts[1].SetActive(false);
        hearts[2].SetActive(false);
        audioManagerScript.PlayAudio(wallCrash);
        audioManagerScript.PlayAudio(hurtSound);
        gameOverScript.EndGame(score);
    }

    public float GetMoveSpeed() {
        return Mathf.Min(score / moveSpeedScaler + baseMoveSpeed, maxMoveSpeed);
    }

    void IncreaseScore() {
        score += 1;
    }

}
