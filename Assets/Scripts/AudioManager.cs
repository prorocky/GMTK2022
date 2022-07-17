using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource outAudio;
    // Start is called before the first frame update

    public void PlayAudio(AudioClip audiofile) {
        outAudio.PlayOneShot(audiofile);
    }
}
