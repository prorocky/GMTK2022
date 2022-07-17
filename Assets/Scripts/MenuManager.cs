using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Script Reference To Leaderboard")]
    [SerializeField] public Leaderboard leaderboard;
    
    void Awake() {
        Time.timeScale = 1f;

    }
    

    void Start() {
        StartCoroutine(SetupRoutine());
    }

    public void StartGame() {
        SceneManager.LoadScene(0);
    }

    public void CloseGame() {
        Application.Quit();
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    public void GoToMenu() {
        SceneManager.LoadScene(1);
    }

    public void UpdateLeaderboards(){
        StartCoroutine(UpdateLeaderboard());
    }

    public IEnumerator UpdateLeaderboard() {
        yield return leaderboard.FetchTopHighscoresRoutine();
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


}
