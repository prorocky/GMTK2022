using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackGroundMusic : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] public AudioSource Audio;
    [SerializeField] public static bool AudioPlaying = true;
    [SerializeField] public bool checkingaudio = true;
    
    void Start() {
        if (Audio.isPlaying){
            print("audio is on");
        }
    }

    void Update() {
        if (!Audio.isPlaying && checkingaudio){
            AudioPlaying = false;
            checkingaudio = false;
        }
        
    }
    
}