using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]

    [Header("General")]
    [SerializeField] public int score;
    [SerializeField] private int health;
    [SerializeField] public int tileSpawnNo;
    [SerializeField] public int obstacleSpawnFrequency;     // Every x tiles spawn an obstacle/wall
    



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
        
    }

    public void loseHealth() {
        health--;
        if (health <= 0)
            EndGame();
    }

    // Function for what to do once loss condition is reached
    public void EndGame() {

    }
}
