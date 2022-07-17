using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LegMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float switchLaneSpeed = 1f;
    [SerializeField] private float leftLaneXPosition = -2f;
    [SerializeField] private float middleLaneXPosition = 0f;
    [SerializeField] private float rightLaneXPosition = 2f;

    [Header("CurrentScore")]
    [SerializeField] TMP_Text Score;
    [SerializeField] public float currentScore = 0f;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player's score
        currentScore = transform.position.z;
        Score.text = "Score: " + currentScore.ToString("F0");

        //player's movement
        targetPosition = transform.position - new Vector3(0,0, -100f);
        var moveZStep = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveZStep);

        if(Input.GetKeyDown("q") && !(Time.timeScale == 0)){
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
        if(Input.GetKeyDown("e") && !(Time.timeScale == 0)){
            // In middle lane, move right
            if(transform.position.x == middleLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }

            // In left lane, move rightc
            if(transform.position.x == leftLaneXPosition){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(middleLaneXPosition, transform.position.y, transform.position.z), switchLaneSpeed);
            }          
        }
    }
}
