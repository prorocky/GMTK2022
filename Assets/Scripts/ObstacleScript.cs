using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Header("References")]

    [SerializeField] GameManager gameManager;
    [Header("General")]
    [SerializeField] public int value;
    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(1, 7);    // (inclusive, exclusive)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        // check for value of player being equal to value of obstacle
        if (collider.gameObject.GetComponent<SideDetection>().dieCurrentFace == value) {
            (gameManager.score)++;
            // play sound effect for getting point
            Destroy(gameObject);    // Destroy to prevent being able to swap back and forth retriggering collision
        } else {
            gameManager.loseHealth();
        }
    }
}
