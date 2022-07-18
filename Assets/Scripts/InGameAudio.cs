using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameAudio : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] public AudioSource audio;
    [SerializeField] private GameObject audioOnIcon;
    [SerializeField] private GameObject audioOffIcon;
    // Update is called once per frame
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "InGame"){
            if (!BackGroundMusic.AudioPlaying){
                audio.volume = 0f;
            }
        }

        if (audio.volume > 0) {
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }else {
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (audio.volume > 0) {
                audio.volume = 0;
                audioOnIcon.SetActive(false);
                audioOffIcon.SetActive(true);
            }else {
                audio.volume = 0.12f;
                audioOnIcon.SetActive(true);
                audioOffIcon.SetActive(false);
            }
        }
    }
}
