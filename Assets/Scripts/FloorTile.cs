using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask playerLayer;
    
    private FloorSpawner floorSpawner;
    void Awake()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
    }

    private void OnTriggerEnter(Collider col) 
    {   
        if (col.gameObject.layer == 6) {
            floorSpawner.SpawnTile();
            Destroy(gameObject, 3);
        }
    }
}
