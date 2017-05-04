using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject deathParticles;

    private Vector3 input;
    private float maxSpeed = 5f;
    private Rigidbody rigid;
    private Vector3 spawn;

    // Use this for initialization
    void Start()
    {
        spawn = transform.position;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude < maxSpeed)
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            rigid.AddForce(input * moveSpeed);
        }

        if (transform.position.y <-2)
        {
            Die();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "Goal1")
        {
            GameManager1.CompleteLevel();
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }

}
