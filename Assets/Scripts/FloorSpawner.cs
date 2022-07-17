using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int initialSpawnCount = 2;
    [SerializeField] private int numObstacles = 3;
    [SerializeField] private int envDieAmountMax = 5;
    [SerializeField] private float envDieXShift = 30f;
    [SerializeField] private float envDieZShift = 50f;
    [SerializeField] private int[] scaleShiftLimits = new int[] {2, 4};

    [Header("References")]
    [SerializeField] public GameManager gameManager;
    [SerializeField] public GameObject floorTile;
    [SerializeField] private GameObject environmentDie;
    [SerializeField] private Vector3 nextSpawnPoint;
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject wallPrefab;
    // [SerializeField] private GameObject[] numberPrefabs;

    // Start is called before the first frame update
    void Start() 
    {
        for (int i = 0; i < initialSpawnCount; i++) {
            SpawnTileNoObstacle();
        }
    }

    // created new spawn function to spawn without obstacles
    public void SpawnTileNoObstacle() {
        gameManager.tileSpawnNo++;
        GameObject groundTileSpawn = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = groundTileSpawn.transform.GetChild(0).transform.position;
        SpawnEnvironmentDie();
    }

    // spawns new floor tile at the end position nextSpawnPoint
    public void SpawnTile() {
        gameManager.tileSpawnNo++;
        GameObject groundTileSpawn = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = groundTileSpawn.transform.GetChild(0).transform.position;
        CreateObstacles(groundTileSpawn, gameManager.score);
        SpawnEnvironmentDie();
    }

    public void SpawnEnvironmentDie() {
        int leftSideDieAmount = Random.Range(0, envDieAmountMax);
        int rightSideDieAmount = Random.Range(0, envDieAmountMax);

        
        for(int i = 0; i < leftSideDieAmount; i++) {
            Vector3 spawnOffset = SpawnOffsetCalculator(-1);
            GameObject envDieSpawn = Instantiate(environmentDie, spawnOffset, Quaternion.identity);

            ObjectScaleChange(envDieSpawn);
            // float scaleChangeValue = Random.Range(4, 8);
            // Vector3 scaleChange = new Vector3 (scaleChangeValue, scaleChangeValue, scaleChangeValue);
            // envDieSpawn.transform.localScale += scaleChange;
        }

        for(int i = 0; i < rightSideDieAmount; i++) {
            Vector3 spawnOffset = SpawnOffsetCalculator(1);
            GameObject envDieSpawn = Instantiate(environmentDie, spawnOffset, Quaternion.identity);

            ObjectScaleChange(envDieSpawn);
        }
    }

    public Vector3 SpawnOffsetCalculator(int side) {
        float xAxis = Random.Range(0, 20);
        float yAxis = Random.Range(0, 20);
        float zAxis = Random.Range(0, 20);


        Vector3 newOffset = nextSpawnPoint + new Vector3 (envDieXShift * side, 0f, envDieZShift);
        newOffset += new Vector3 (xAxis, yAxis, zAxis);

        return newOffset;
    }

    public void ObjectScaleChange(GameObject spawnedObject) {
        float scaleChangeValue = Random.Range(scaleShiftLimits[0], scaleShiftLimits[1]);
        Vector3 scaleChange = new Vector3 (scaleChangeValue, scaleChangeValue, scaleChangeValue);
        spawnedObject.transform.localScale *= scaleChangeValue;
    }

    // At start, allow for "holes" where player can go through without getting points
    // As time goes on/score increases, open holes will not appear
    // Eventually when score gets high enough the only configuration will be 1 obstacle and 2 walls
    public void CreateObstacles(GameObject tile, int currentScore) {
        int obstacleIndex, obstacleIndex2;

        // 1 obstacle, 2 holes
        switch (currentScore) {
            case int n when n < 100:
                obstacleIndex = Random.Range(0, 3);
                for (int i = 0; i < numObstacles; i++) {
                    int xcoord = i * 2 - 2;
                    int zcoord = (int)nextSpawnPoint.z + 10;
                    Vector3 spawnPosition = new Vector3(xcoord, 1, zcoord);
                    if (i == obstacleIndex) {
                        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, tile.transform);
                        // int obstacleNumber = spawnedObstacle.GetComponent<ObstacleScript>().GetValue();
                        // print("Obstacle Number: " + obstacleNumber);
                        // Vector3 numberOffset = new Vector3(0f, 0f, obstacleNumberOffset);
                        // Instantiate(numberPrefabs[obstacleNumber], spawnPosition - numberOffset, Quaternion.identity, spawnedObstacle.transform);
                    } else {
                        Instantiate(holePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    }
                }
                break;

            // 2 obstacles, 1 hole
            case int n when n < 180:
                obstacleIndex = Random.Range(0, 3);
                obstacleIndex2 = Random.Range(0, 3);
                while (obstacleIndex == obstacleIndex2) {
                    obstacleIndex2 = Random.Range(0, 3);
                }
                for (int i = 0; i < numObstacles; i++) {
                    int xcoord = i * 2 - 2;
                    int zcoord = (int)nextSpawnPoint.z + 10;
                    Vector3 spawnPosition = new Vector3(xcoord, 1, zcoord);
                    if (i == obstacleIndex || i == obstacleIndex2) {
                        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    } else {
                        Instantiate(holePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    }
                }
                break;

            // 1 obstacles, 1 wall, 1 hole
            case int n when n < 280:
                obstacleIndex = Random.Range(0, 3);
                obstacleIndex2 = Random.Range(0, 3);        // using obstacle2 as the index for the wall in this case
                while (obstacleIndex == obstacleIndex2) {
                    obstacleIndex2 = Random.Range(0, 3);
                }
                for (int i = 0; i < numObstacles; i++) {
                    int xcoord = i * 2 - 2;
                    int zcoord = (int)nextSpawnPoint.z + 10;
                    Vector3 spawnPosition = new Vector3(xcoord, 1, zcoord);
                    if (i == obstacleIndex) {
                        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    } else if (i == obstacleIndex2) {
                        Instantiate(wallPrefab, spawnPosition, Quaternion.identity, tile.transform);
                    } else {
                        Instantiate(holePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    }
                }
                break;
            
            // 2 obstacles, 1 wall
            case int n when n < 400:
                obstacleIndex = Random.Range(0, 3);
                obstacleIndex2 = Random.Range(0, 3);
                while (obstacleIndex == obstacleIndex2) {
                    obstacleIndex2 = Random.Range(0, 3);
                }
                for (int i = 0; i < numObstacles; i++) {
                    int xcoord = i * 2 - 2;
                    int zcoord = (int)nextSpawnPoint.z + 10;
                    Vector3 spawnPosition = new Vector3(xcoord, 1, zcoord);
                    if (i == obstacleIndex || i == obstacleIndex2) {
                        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    } else {
                        Instantiate(wallPrefab, spawnPosition, Quaternion.identity, tile.transform);
                    }
                }
                break;
            
            // 1 obstacle, 2 walls
            default:
                obstacleIndex = Random.Range(0, 3);
                for (int i = 0; i < numObstacles; i++) {
                    int xcoord = i * 2 - 2;
                    int zcoord = (int)nextSpawnPoint.z + 10;
                    Vector3 spawnPosition = new Vector3(xcoord, 1, zcoord);
                    if (i == obstacleIndex) {
                        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, tile.transform);
                    } else {
                        Instantiate(wallPrefab, spawnPosition, Quaternion.identity, tile.transform);
                    }
                }
                break;

        }
    }
}
