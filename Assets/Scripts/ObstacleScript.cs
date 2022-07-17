using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    [SerializeField] SideDetection side;

    [Header("General")]
    [SerializeField] public int value;
    [SerializeField] private int playerLayer = 6;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        side = GameObject.FindObjectOfType<SideDetection>();
        value = Random.Range(1, 7);    // (inclusive, exclusive)
        print(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        // check if collider is player
        if (collider.gameObject.layer == playerLayer) {
        
            // check for value of player being equal to value of obstacle
            if (side.dieCurrentFace == value) {
                (gameManager.score)++;
                // play sound effect for getting point
                
            } else {
                gameManager.loseHealth();
            }
            Destroy(gameObject);    // Destroy to prevent being able to swap back and forth retriggering collision
        }
    }
}
