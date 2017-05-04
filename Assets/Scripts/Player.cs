using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ctrl + M + O = folds your code
// Ctrl + M + P = unfold your code

public class Player : MonoBehaviour
{
    // Prefab Added after creating it
    public GameObject explosionPrefab;
    public float movementSpeed = 20f;
    public float maxSpeed = 5f;

    private Rigidbody rigid;
    //Added same time as prefab
    private Vector3 startPos;


    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        rigid = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(inputHoriz, 0, inputVert);

        if (rigid.velocity.magnitude < maxSpeed)
        {
            rigid.AddForce(force * movementSpeed);
        }



    }

    //Unity-specific function that gets called
    // when the gameobject hits another collider
    void OnTriggerEnter(Collider col)
    {
        // Check if we hitting the goal
        if(col.tag == "Goal")
        {
            // complete the levelS
            GameManager.CompleteLevel();
        }
        // Check if we hit the enemy
        if (col.tag == "Enemy")
        {
            // Kill off the player
            Die();
        }

    }

    void Die()
    {
        // Play the explosion
        PlayExplosion();
        // Reset position of players
        transform.position = startPos;
        // Remove all velocity from player when dead
        rigid.velocity = Vector3.zero;
    }

    void PlayExplosion()
    {
        // Create a copy of our explosion
        GameObject clone = Instantiate(explosionPrefab);
        clone.transform.position = transform.position;
        // Play the particle system
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>();
        explosion.Play();

    }






}
