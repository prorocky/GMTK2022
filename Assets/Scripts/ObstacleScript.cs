using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    [SerializeField] SideDetection side;
    [SerializeField] private GameObject[] numberPrefabs;

    [Header("General")]
    [SerializeField] public int value;
    [SerializeField] private int playerLayer = 6;
    [SerializeField] private Vector3 obstacleNumberOffset = new Vector3 (0f, 0f, 2f);

    [Header("Audio")]
    [SerializeField] private AudioManager audioScriptReference;
    [SerializeField] private AudioClip happyNoise;
    [SerializeField] private AudioClip hurtNoise;
    //[SerializeField] private AudioSource outAudio;
    // Start is called before the first frame update
    void Start()
    {
        audioScriptReference = GameObject.Find("HappyNoise").GetComponent<AudioManager>();
        value = Random.Range(1, 7);
        print("VALUE:" + value);
        gameManager = GameObject.FindObjectOfType<GameManager>();
        side = GameObject.FindObjectOfType<SideDetection>();
        GameObject spawnedNumber = Instantiate(numberPrefabs[value - 1], transform.position - obstacleNumberOffset, transform.rotation);
        spawnedNumber.transform.rotation *= Quaternion.Euler(-90f, 180f, 0f);
    }


    void OnTriggerEnter(Collider collider) {
        // check if collider is player
        if (collider.gameObject.layer == playerLayer) {
        
            // check for value of player being equal to value of obstacle
            if (side.dieCurrentFace == value) {
                audioScriptReference.PlayAudio(happyNoise);
                gameManager.score += 20;
                // play sound effect for getting point
                
            } else {
                audioScriptReference.PlayAudio(hurtNoise);
                gameManager.LoseHealth();
            }
            Destroy(gameObject);    // Destroy to prevent being able to swap back and forth retriggering collision
        }
    }
}
