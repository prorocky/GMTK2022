using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManagerScript;
    
    [Header("General")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float switchLaneSpeed = 1f;
    [SerializeField] private float leftLaneXPosition = -2f;
    [SerializeField] private float middleLaneXPosition = 0f;
    [SerializeField] private float rightLaneXPosition = 2f;
    [SerializeField] private bool moveLeft = false;
    [SerializeField] private bool moveRight = false;
    
    [Header("Audio")]
    [SerializeField] private AudioClip laneChange;
    [SerializeField] private AudioSource outAudio;

    private Vector3 targetPosition;

    void Update()
    {

        //player's movement
        targetPosition = transform.position - new Vector3(0,0, -100f);
        var moveZStep = gameManagerScript.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveZStep);

        // Switch to Left Lane
        //if(Input.GetKeyDown("q") && !(Time.timeScale == 0)){
        //if((Input.touches[0].position.x <= Screen.width / 2) && (Input.touches[0].phase == TouchPhase.Began) && !(Time.timeScale == 0)){
        if(moveLeft && !(Time.timeScale == 0)){
            // In middle lane, move left
            if(transform.position.x == middleLaneXPosition){
                outAudio.PlayOneShot(laneChange);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(leftLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }

            // In right lane, move left
            if(transform.position.x == rightLaneXPosition){
                outAudio.PlayOneShot(laneChange);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(middleLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }       
            moveLeft = false;   
        }

        // Switch to Right Lane
        // if(Input.GetKeyDown("e") && !(Time.timeScale == 0)){
        //if((Input.touches[0].position.x > Screen.width / 2) && (Input.touches[0].phase == TouchPhase.Began) && !(Time.timeScale == 0)){
        if(moveRight && !(Time.timeScale == 0)){
            // In middle lane, move right
            if(transform.position.x == middleLaneXPosition){
                outAudio.PlayOneShot(laneChange);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }

            // In left lane, move rightc
            if(transform.position.x == leftLaneXPosition){
                outAudio.PlayOneShot(laneChange);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(middleLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }          
            moveRight = false;
        }
    }

    public void ButtonToMoveLeft(){
        moveLeft = true;
    }

    public void ButtonToMoveRight(){
        moveRight = true;
    }
}
