using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float smoothSpeed;

    [Header("Reference")]
    [SerializeField] private Transform target;

    private Vector3 targetPosition;

    void Start(){
        transform.position = new Vector3(target.position.x, target.position.y + 2f, target.position.z - 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y + 2f, target.position.z - 5f);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        targetPosition = transform.position - new Vector3(0,0, -100f);
        var step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        
    }
}
