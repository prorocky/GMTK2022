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

    private void OnCollisionEexit(Collision col) 
    {
        print("in exit");
        floorSpawner.SpawnTile();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
