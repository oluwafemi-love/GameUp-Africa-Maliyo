using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        //For the enemy to know the Player's Position, we get that by subtracting the distance of the enemy from the player
        //For Femi to know and get to where Kehinde is, Femi will subtract the distance from his own position with the position of where Kehinde is.
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce( lookDirection * speed);

        //If the enemy is no longer on the hill, that is fallen off, destroy the enemy.
        if(gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
