
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
        //random number in the start function, random between elements in the array
        randomSpot = Random.Range(0,moveSpots.Length);

    }

    void Update() 
    {
        //gets character to move towards location, random position in the array, speed
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        //checking if character has reached destination, makes character wait and move to another random location
        //checks distance between character and destination
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) 
        {
            //checks if time for character to move to another destination
            if (waitTime <= 0)
            {
                //random spot generation
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
        //uses animations for when the character moves
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() 
    {
        //character animation movement 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
