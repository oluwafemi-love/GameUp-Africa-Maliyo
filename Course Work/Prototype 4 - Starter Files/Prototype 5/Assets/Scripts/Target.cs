using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //FEMI'S NOTE: Target is like our Player in previous lesson, because the story is quite different: we are picking our targets and avoiding the baddies(bad skullful targets).
    //So, everything that happens to our target, the speed at which they move, how they turn, where they appear, and how we pick them, plus how they get destroyed, happens in this codefile.

    Rigidbody targetRb;
    GameManager gameManager;
    float minSpeed = 8; //12
    float maxSpeed = 12; //16
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -6;

    public int pointValue;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //Find the GameManager Script in other to acess the methods in it.
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //make it jump up
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //make it spin round/rotate.
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse );

        //make it show at different position or location.
        targetRb.transform.position = RandomSpawnPos();

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //Instantiate Particle System
            gameManager.UpdateScore(pointValue); //Call the Update Score function in GameManager to perform it's work: increase the score.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
           // gameManager.isGameActive = false;
            gameManager.GameOver();

        }
    }


    //CUSTOM METHODS: built by yours truly.
    Vector3 RandomForce()
    {
        //give random speed to the force applied on each item/object. ti nkan ba fo so ke gan, imi ma fo so ke die.
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }


  
}
