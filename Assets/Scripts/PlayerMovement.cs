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
        // Get the rotation, if any
        float x = 0f, y = 0f;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            x = 90f;
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            x = -90f;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            y = 90f;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            y = -90f;
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
