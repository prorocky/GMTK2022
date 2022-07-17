using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDetection : MonoBehaviour
{
    [Header("General")]
    [SerializeField] public int dieCurrentFace = 1;

    [Header("Reference")]
    [SerializeField] private Transform target;

    void Update(){
        print("CURRENT FACE: " + dieCurrentFace);
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z - 1.5f);
        transform.position = targetPos;
    }

    private void OnTriggerEnter(Collider col){
        print("COL: " + col.tag);
        switch(col.tag){
            case "Side1":
            dieCurrentFace = 1;
            break;

            case "Side2":
            dieCurrentFace = 2;
            break;

            case "Side3":
            dieCurrentFace = 3;
            break;

            case "Side4":
            dieCurrentFace = 4;
            break;

            case "Side5":
            dieCurrentFace = 5;
            break;

            case "Side6":
            dieCurrentFace = 6;
            break;
        }
    }
}
