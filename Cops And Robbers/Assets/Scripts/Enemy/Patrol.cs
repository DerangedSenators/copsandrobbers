
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;
    

    void Start() 
    {
        randomSpot = Random.Range(0,moveSpots.Length);

    }

    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) 
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
