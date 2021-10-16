using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellerX : MonoBehaviour
{
    float RotationSpeed = 15.0f;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed );
    }
}
