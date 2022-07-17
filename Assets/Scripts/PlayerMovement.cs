using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float rotateDuration = 1f;
    [SerializeField] private float rotationSpeed = 10f;
   
    private Vector3 targetPosition;
    private bool rotating = false;
    private Quaternion newRotation;
    private Quaternion oldRotation;

    void Start()
    {
        newRotation = oldRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Roll Dice
        UpdateRotationState();

        if(rotateDuration < 1f){
            rotateDuration += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(oldRotation, newRotation, rotateDuration);
        }
    }

    void UpdateRotationState(){
        // Get the rotation, if any
        float x = 0f, y = 0f;
        if (Input.GetKeyDown(KeyCode.W))
        {
            // print("Forward");
            x = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // print("Back");
            x = -90f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // print("Left");
            y = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // print("Right");
            y = -90f;
        }
        // if rotation is nonzero, apply it
        if (x != 0f || y != 0f)
        {
            newRotation = Quaternion.Euler(x, y, 0f) * newRotation;
            oldRotation = transform.rotation;
            rotateDuration = 0f;
        }
    }

    IEnumerator Rotate(Quaternion shift){
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * shift;
        print("TARGET: " + targetRotation.x);

        while(timeElapsed < rotateDuration){
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotateDuration );
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        rotating = false;
    }
}
