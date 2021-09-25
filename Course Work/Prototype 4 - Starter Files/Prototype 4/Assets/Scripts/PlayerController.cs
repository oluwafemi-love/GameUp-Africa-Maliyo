using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerupIndicator;
    
    public float speed = 5.0f;
    public bool hasPowerUp = false;
    private float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //MY VERSION:
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    playerRb.AddForce(Vector3.forward * speed);
        //    Debug.Log("Up Arrow Pressed!");
        //}

        //QuickTip: ForwardInput === DIRECTION the ball will follow when triggered.
        float forwardInput = Input.GetAxis("Vertical");
        // playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        //Make the PowerUpIndicator follow the player about.
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);

            Destroy(other.gameObject);

            Debug.Log("Powered Up!");
        }

        StartCoroutine(PowerupCountdownRoutine());
    }

    //There is a neeed for us to make the PowerUp expire at some point and we leverage on IEnumerator power to make the portion of the code run for some certain time and then expire: In this case, run for 7 Seconds.
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {   
            //Really! We collided with the enemy and now we are using that event(collision) to get the details of the enemy and hereby do supawafu things.
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            
            /*Kinda tricky the same way we got the position of the player from the enemy by subtracting...(See Enemy.cs script) 
             * that same formular we applied here: subtracting the position the player is from the position the enemy is*/
            Vector3 moveAway = collision.gameObject.transform.position - transform.position;

            //Enemy lo ko lu wa, owun ni nkan se! Agabra be!
            enemyRigidbody.AddForce(moveAway * powerupStrength, ForceMode.Impulse);


            Debug.Log("You collided with " + collision.gameObject.name + " with a " + hasPowerUp + " Superpower to knock em off!");
        }
    }
}
