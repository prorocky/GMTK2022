using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boofMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(0, 0, moveSpeed);
    }
}
