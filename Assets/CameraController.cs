using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float[] cameraOffset = new float[] {2f, 5f};
    private Vector3 targetPosition;

    void Start(){
        transform.position = new Vector3(target.position.x, target.position.y + cameraOffset[0], target.position.z - cameraOffset[1]);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y + cameraOffset[0], target.position.z - cameraOffset[1]);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        targetPosition = transform.position - new Vector3(0,0, -100f);
        var step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        
    }
}
