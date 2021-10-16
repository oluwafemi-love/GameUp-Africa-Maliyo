using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15;

    //We Need a Swipe Feature: 48:15
    private bool isTravelling;
    private Vector3 travelDirection;
    private Vector3 nextCollisionPosition;
    //....
    public int minSwipeRecognition = 500;
    private Vector2 swipePosLastFrame;
    private Vector2 swipePosCurrentFrame;
    private Vector2 currentSwipe;


    //We want to Change Colors
    private Color solveColor;

    private void Start()
    {
        //we are changing colors and randomizing em... you know.
        solveColor = Random.ColorHSV(0.5F, 1);
        GetComponent<MeshRenderer>().material.color = solveColor;
    }

    public void FixedUpdate()
    {
        if (isTravelling) //Move only when you can Move in the direction you follow
        {
            rb.velocity = speed * travelDirection;

        }

        //We want to change the color of the Ground... you know.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position - (Vector3.up / 2), 0.05f);
        int i = 0;
        while(i < hitColliders.Length)
        {
            GroundPiece ground = hitColliders[i].transform.GetComponent<GroundPiece>();
            if(ground && !ground.isColored)
            {
                ground.ChangeColor(solveColor);
            }
            i++;
        }


        if(nextCollisionPosition != Vector3.zero) //Omo na 54:14, explantion e ki
        {
            if(Vector3.Distance(transform.position, nextCollisionPosition) < 1)
            {
                isTravelling = false; //movement has stopped, so stop.
                travelDirection = Vector3.zero; //don't move anymore
                nextCollisionPosition = Vector3.zero;
            }
        }

        if (isTravelling) //Swipe Mechanism in a bit, but before then if the ball is moving, do nothing.
            return;

        if (Input.GetMouseButton(0))
        {
            swipePosCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if(swipePosLastFrame != Vector2.zero)
            {
                currentSwipe = swipePosCurrentFrame - swipePosLastFrame;

                if(currentSwipe.sqrMagnitude < minSwipeRecognition)
                {
                    return;
                }

                currentSwipe.Normalize();
                
                //UP / DOWN
                if(currentSwipe.x > -0.5f && currentSwipe.x < 0.5)
                {
                    //GO UP / DOWN
                    SetDestination(currentSwipe.y > 0 ? Vector3.forward : Vector3.back);
                }
                if (currentSwipe.y > -0.5f && currentSwipe.y < 0.5)
                {
                    //GO LEFT/RIGHT
                    SetDestination(currentSwipe.x > 0 ? Vector3.right : Vector3.left); 
                }
            }
            swipePosLastFrame = swipePosCurrentFrame;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipePosLastFrame = Vector2.zero;
            currentSwipe = Vector2.zero;
        }
    }


    private void SetDestination(Vector3 direction)
    {
        travelDirection = direction;
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, direction, out hit, 100f))
        {
            nextCollisionPosition = hit.point;
        }

        isTravelling = true;
    }

}
