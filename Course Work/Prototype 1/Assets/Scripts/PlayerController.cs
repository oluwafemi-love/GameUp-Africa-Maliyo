using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //I am getting the player's input...
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // I  make the car move:
        transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * forwardInput);  //foward or backward
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);  //move right or left
        transform.Rotate(Vector3.up, (Time.deltaTime * turnSpeed * horizontalInput) ); // Rotate right or left
       
    }
}
