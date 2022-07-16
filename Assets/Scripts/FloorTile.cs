using UnityEngine;

public class FloorTile : MonoBehaviour
{
    FloorSpawner floorSpawner;
    // Start is called before the first frame update
    void Start()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
    }

    private void OnTriggerExit(Collider collider) 
    {
        floorSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
