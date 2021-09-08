using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float delayTime;
    // Update is called once per frame
    void Update()
    {
        delayTime +=  Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && delayTime > 1.0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            delayTime = 0f;
        }

        
    }
}
