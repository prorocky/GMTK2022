using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int initialSpawnCount = 4;
    [SerializeField] private int envDieAmountMax = 5;
    [SerializeField] private float envDieXShift = 30f;
    [SerializeField] private int[] scaleShiftLimits = new int[] {2, 4};

    [Header("References")]
    [SerializeField] public GameObject floorTile;
    [SerializeField] private GameObject environmentDie;
    [SerializeField] private Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start() 
    {
        for (int i = 0; i < initialSpawnCount; i++) {
            SpawnTile();
        }
    }

    public void SpawnTile() {
        GameObject groundTileSpawn = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = groundTileSpawn.transform.GetChild(0).transform.position;
        SpawnEnvironmentDie();
    }

    public void SpawnEnvironmentDie() {
        int leftSideDieAmount = Random.Range(0, envDieAmountMax);
        int rightSideDieAmount = Random.Range(0, envDieAmountMax);

        
        for(int i = 0; i < leftSideDieAmount; i++) {
            Vector3 spawnOffset = SpawnOffsetCalculator(-1);
            GameObject envDieSpawn = Instantiate(environmentDie, spawnOffset, Quaternion.identity);

            objectScaleChange(envDieSpawn);
            // float scaleChangeValue = Random.Range(4, 8);
            // Vector3 scaleChange = new Vector3 (scaleChangeValue, scaleChangeValue, scaleChangeValue);
            // envDieSpawn.transform.localScale += scaleChange;
        }

        for(int i = 0; i < rightSideDieAmount; i++) {
            Vector3 spawnOffset = SpawnOffsetCalculator(1);
            GameObject envDieSpawn = Instantiate(environmentDie, spawnOffset, Quaternion.identity);

            objectScaleChange(envDieSpawn);
        }
    }

    public Vector3 SpawnOffsetCalculator(int side) {
        float xAxis = Random.Range(0, 20);
        float yAxis = Random.Range(0, 20);
        float zAxis = Random.Range(0, 20);


        Vector3 newOffset = nextSpawnPoint + new Vector3 (envDieXShift * side, 0f, 0f);
        newOffset += new Vector3 (xAxis, yAxis, zAxis);

        return newOffset;
    }

    public void objectScaleChange(GameObject spawnedObject) {
        float scaleChangeValue = Random.Range(scaleShiftLimits[0], scaleShiftLimits[1]);
        Vector3 scaleChange = new Vector3 (scaleChangeValue, scaleChangeValue, scaleChangeValue);
        spawnedObject.transform.localScale *= scaleChangeValue;
    }
}
