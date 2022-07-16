using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    public GameObject floorTile;
    [SerializeField]
    Vector3 nextSpawnPoint;

    public void SpawnTile() 
    {
        GameObject temp = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start() 
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnTile();
        }
    }

}
