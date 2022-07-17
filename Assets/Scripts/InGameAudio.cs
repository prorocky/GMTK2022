using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameAudio : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] public AudioSource Audio;

    // Update is called once per frame
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene"){
            if (!BackGroundMusic.AudioPlaying){
                Audio.volume = 0f;
            }
        }
    }
}
