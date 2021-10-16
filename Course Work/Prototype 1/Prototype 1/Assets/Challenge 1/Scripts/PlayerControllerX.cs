using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //private float speed = 2.5f;
    public float rotationSpeed = 15.0f;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get the user's rotation input
        horizontalInput = Input.GetAxis("Horizontal");

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * rotationSpeed * verticalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * horizontalInput);


    }
}
