using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject floorTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile() 
    {
        GameObject temp = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start() 
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }

}
