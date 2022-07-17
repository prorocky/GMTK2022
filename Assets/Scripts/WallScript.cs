using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    
    [Header("General")]
    [SerializeField] private int playerLayer = 6;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        // if player hits wall, game over
        if (collider.gameObject.layer == playerLayer) {
            gameManager.EndGame();
        }
    }
}
