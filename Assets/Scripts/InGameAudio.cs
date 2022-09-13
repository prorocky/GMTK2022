using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InGameAudio : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] public AudioSource audio;
    [SerializeField] public GameObject PauseScreen;
    [SerializeField] TextMeshProUGUI countDown;

    //[SerializeField] Slider volumeSlider;
    // Update is called once per frame
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "InGame"){
            if (!BackGroundMusic.AudioPlaying){
                audio.volume = 0f;
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            PauseScreen.SetActive(true);
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        countDown.enabled = true;
        StartCoroutine(CountDown());
        
    }

    IEnumerator CountDown() {
        countDown.text = "3";
        yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
        countDown.text = "2";
        yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
        countDown.text = "1";
        yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
        Time.timeScale = 1;
        countDown.enabled = false;
    }

}
