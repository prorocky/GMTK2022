using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float rotateDuration = 1f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("References")]
    [SerializeField] private AudioClip dieFlipSound;
    [SerializeField] private AudioManager audioManagerScript;

    [Header("Mobile")]
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    [SerializeField] private bool stopTouch = false;
    [SerializeField] private float swipeRange;
   
    private Vector3 targetPosition;
    // private bool rotating = false;
    private Quaternion newRotation;
    private Quaternion oldRotation;

    void Start()
    {
        audioManagerScript = GameObject.Find("DieFlipNoise").GetComponent<AudioManager>();
        newRotation = oldRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Roll Dice
        UpdateRotationState();

        if(rotateDuration < 1f){
            rotateDuration += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, rotateDuration);
        }
    }

    void UpdateRotationState(){
        // Swiping Code
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            currentPosition = Input.GetTouch(0).position;
            Vector3 Distance = currentPosition - startTouchPosition;

            if(!stopTouch){

                // Get the rotation, if any
                float x = 0f, y = 0f;
                //if (Input.GetKeyDown(KeyCode.W)) {
                if(Distance.y > swipeRange){
                    x = 90f;
                    stopTouch = true;
                } 
                else if (Distance.y < -swipeRange){
                //else if (Input.GetKeyDown(KeyCode.S)) {
                    x = -90f;
                    stopTouch = true;
                }

                //if (Input.GetKeyDown(KeyCode.A)) {
                else if(Distance.x < -swipeRange){
                    y = 90f;
                    stopTouch = true;
                } 
                else if (Distance.x > swipeRange){
                //else if (Input.GetKeyDown(KeyCode.D)) {
                    y = -90f;
                    stopTouch = true;
                }

                // if rotation is nonzero, apply it
                if (x != 0f || y != 0f)
                {
                    audioManagerScript.PlayAudio(dieFlipSound);
                    newRotation = Quaternion.Euler(x, y, 0f) * newRotation;
                    oldRotation = transform.rotation;
                    rotateDuration = 0f;
                }
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector3 Distance = endTouchPosition - startTouchPosition;
        }

    }
    // IEnumerator Rotate(Quaternion shift){
    //     rotating = true;
    //     float timeElapsed = 0;
    //     Quaternion startRotation = transform.rotation;
    //     Quaternion targetRotation = transform.rotation * shift;
    //     print("TARGET: " + targetRotation.x);

    //     while(timeElapsed < rotateDuration){
    //         transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotateDuration );
    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     transform.rotation = targetRotation;
    //     rotating = false;
    // }
}
