using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowBound = -10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes pass the player's view in the game, remove that object.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowBound)
        {
            // If the animal pass the player without being fed, it's a game over
            // So if the animal pass the lowerbound it is a game over and yes it will be destroyed.
            Debug.Log("Game Over!!!");
            Destroy(gameObject);
        }
    }
}
