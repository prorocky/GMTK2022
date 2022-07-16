using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    FloorSpawner floorSpawner;
    [SerializeField]
    LayerMask playerLayer;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

    }
}
