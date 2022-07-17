using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalCube : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float rotationAngleLimit = 10f;

    float randRotateX;
    float randRotateY;
    float randRotateZ;

    void Start() {
        randRotateX = Random.Range(0, rotationAngleLimit);
        randRotateY = Random.Range(0, rotationAngleLimit);
        randRotateZ = Random.Range(0, rotationAngleLimit);
    }

    void Update() {
        gameObject.transform.Rotate(randRotateX * Time.deltaTime, randRotateY * Time.deltaTime, randRotateZ * Time.deltaTime);
    }
}
