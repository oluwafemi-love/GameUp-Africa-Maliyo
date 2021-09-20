using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce = 5.0f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public bool isLowEnough = false;
    private float upperBound = 16.0f;
    private float lowerBound = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);


    }

    // Update is called once per frame
    void Update()
    {
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y < upperBound)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
       
        }
        //If the player goes above upperbound, make them bounce back.
        if (transform.position.y > upperBound && playerRb.velocity.y > 0)
        {
            playerRb.velocity = Vector3.up * -floatForce / 4;
        }
        //If the player goes below lowerbound, make them bounce up, but allow to fall through when game over.
        if (transform.position.y < lowerBound && !gameOver)
        {
            playerRb.velocity = Vector3.up * floatForce / 4;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // if player collides with the  ground
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
           
        }
    }

}
