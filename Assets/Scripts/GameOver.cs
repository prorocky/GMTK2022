using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI youScored;
    [SerializeField] private GameObject displayScore;
    [SerializeField] private GameObject inputName;
    [SerializeField] private GameObject continueButton;
    //[SerializeField] private GameObject firstscreen;
    [Header("Script Reference To Leaderboard")]
    [SerializeField] public Leaderboard leaderboard;


    // Update is called once per frame
    void Update()
    {

    }


    public void EndGame(int score) {
        StartCoroutine(SubmitScore(score));
        youScored.text = "You Scored: " + score.ToString("F0");
        displayScore.SetActive(true);
        inputName.SetActive(true);
        continueButton.SetActive(true);
        Time.timeScale = 0;     //pause game
        
    }

    IEnumerator SubmitScore(int score){
        yield return leaderboard.SubmitScoreRoutine(score); 
    }
}
