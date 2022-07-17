using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    //[SerializeField] private TMP_Text youScored;
    [SerializeField] private GameObject name;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private bool gameNotOver = true;
    //[SerializeField] private GameObject firstscreen;

    [SerializeField] private LegMovement LegMovementscript;


    // Update is called once per frame
    void Update()
    {
        if ((LegMovementscript.currentScore >= 55) && (gameNotOver)){
            EndGame();
            gameNotOver = false;
        }
    }


    void EndGame() {
        //youScored.text = "You Scored: " + LegMovementscript.currentScore;
        //youScored.meshRenderer.enabled = true;
        //youScored.SetActive(true);
        name.SetActive(true);
        continueButton.SetActive(true);
        Time.timeScale = 0;     //pause game
        
    }
}
