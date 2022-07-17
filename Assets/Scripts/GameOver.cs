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


    // Update is called once per frame
    void Update()
    {

    }


    public void EndGame(int score) {
        youScored.text = "You Scored: " + score.ToString("F0");
        displayScore.SetActive(true);
        inputName.SetActive(true);
        continueButton.SetActive(true);
        Time.timeScale = 0;     //pause game
        
    }
}
