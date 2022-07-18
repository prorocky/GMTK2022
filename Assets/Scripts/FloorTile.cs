using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] public GameManager gameManager;
    
    private FloorSpawner floorSpawner;
    void Awake()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider col) 
    {   
        if (col.gameObject.layer == 6) {
            if (gameManager.tileSpawnNo % gameManager.obstacleSpawnFrequency == 0) {
                if (gameManager.tileSpawnNo <= gameManager.tileSpawnLimit) {
                    floorSpawner.SpawnTile();
                }
            } else {
                if (gameManager.tileSpawnNo <= gameManager.tileSpawnLimit) {
                    floorSpawner.SpawnTileNoObstacle();
                }
            }
            gameManager.tileSpawnNo--;
            Destroy(gameObject, 3);
        }
    }
}
