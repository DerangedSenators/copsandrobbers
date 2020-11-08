using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //reference the animator object within unity
    public Animator animator;

    // Player speed variable
    public float moveSpeed = 5f;
    
    // Variable for character model
    public Rigidbody2D rb;

    // Stores movement value
    Vector2 movement;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        //animator speed 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Update on timer not frames
    void FixedUpdate() {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
