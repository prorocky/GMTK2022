using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //TESTING PURPOSES BELOW IGNORE
    int fakescore = 100;
    bool pass = true;
    //TESTING OVER

    [Header("Script Reference To Leaderboard")]
    [SerializeField] public Leaderboard leaderboard;
    [Header("Custom Name InputField")]
    [SerializeField] public TMP_InputField playerNameInputField;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
        
    }

    

    void Update()
    {
        if (pass){
            StartCoroutine(PlayerDiesOnSpawn());
            pass = false;
        }
    }

    public IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }


    public IEnumerator LoginRoutine()  //makes sure that we have connection with server
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }else{
                Debug.Log("Could not connect to server");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else{
                Debug.Log("Could not set player name");
            }
        });
    }

    //TESTING SUBMISSION OF SCORE IGNORE THIS FUNCTION BELOW
    IEnumerator PlayerDiesOnSpawn(){
        yield return new WaitForSecondsRealtime(3f);
        yield return leaderboard.SubmitScoreRoutine(fakescore);
    }

}
