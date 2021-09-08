using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    //private float leftLimit = 30;
    private float leftLimit = 39.5f;
    private float bottomLimit = -1;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < -leftLimit)
        {
            Destroy(gameObject);
        }else if (transform.position.y < bottomLimit)
        {
            // Destroy balls if y position is less than bottomLimit
            Destroy(gameObject);
        }

    }
}
