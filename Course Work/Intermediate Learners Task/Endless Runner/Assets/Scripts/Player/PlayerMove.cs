using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //As Game starts, start moving
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        
        //Move Left or Right based on the Key pressed.
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide) //Restrict player's movement along the boundary.
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide) //Restrict player's movement along the boundary.
            {
                transform.Translate(Vector3.left * Time.deltaTime * -leftRightSpeed);
            }
        }

    }
}
