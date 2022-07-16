using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    FloorSpawner floorSpawner;
    // Start is called before the first frame update
    void Start()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
    }

    private void OnTriggerExit(Collider other) 
    {
        print("in exit");
        floorSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
