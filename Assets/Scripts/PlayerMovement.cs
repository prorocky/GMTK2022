using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float switchLaneSpeed = 1f;
    [SerializeField] private float rotateDuration = 1f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float leftLaneXPosition;
    [SerializeField] private float middleLaneXPosition;
    [SerializeField] private float rightLaneXPosition;

   

    private Vector3 targetPosition;
    private bool rotating = false;
    private Quaternion newRotation;
    private Quaternion oldRotation;
    
    


    //[Header("Reference")]

    // Start is called before the first frame update
    void Start()
    {
        newRotation = oldRotation = transform.rotation;
        leftLaneXPosition = -2;
        middleLaneXPosition = 0;
        rightLaneXPosition = 2;
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

        // Constantly Move Foward
        targetPosition = transform.position - new Vector3(0,0, -100f);
        var moveZStep = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveZStep);

        // Switch to Left Lane
        if(Input.GetKeyDown("q")){
            // In middle lane, move left
            if(transform.position.x == middleLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(leftLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }

            // In right lane, move left
            if(transform.position.x == rightLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(middleLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }          
        }

        // Switch to Right Lane
        if(Input.GetKeyDown("e")){
            // In middle lane, move right
            if(transform.position.x == middleLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }

            // In left lane, move rightc
            if(transform.position.x == leftLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(middleLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }          
        }

        // // Rotate Upwards
        // if(Input.GetKeyDown("w") && !rotating){
        //     StartCoroutine(Rotate(Quaternion.Euler(90, 0, 0)));
        // }

        // // Rotate Downwards
        // if(Input.GetKeyDown("s") && !rotating){
        //     StartCoroutine(Rotate(Quaternion.Euler(-90, 0, 0)));
        // }

        // // Rotate Left
        // if(Input.GetKeyDown("a") && !rotating){
        //     StartCoroutine(Rotate(Quaternion.Euler(0, 90, 0)));
        // }

        // // Rotate Right
        // if(Input.GetKeyDown("d") && !rotating){
        //     StartCoroutine(Rotate(Quaternion.Euler(0, -90, 0)));
        // }

    }

    void UpdateRotationState(){
        // Get the rotation, if any
        float x = 0f, y = 0f;
        if (Input.GetKeyDown(KeyCode.W))
        {
            x = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            x = -90f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            y = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
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
