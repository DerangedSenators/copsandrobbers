<<<<<<< HEAD:Cops And Robbers/Assets/Scripts/PlayerMovment/PlayerMovment.cs
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

    //speed of animation
    public float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animation controls
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    // Update on timer not frames
    void FixedUpdate() {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        

    }



}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// reference the animator object within unity
        /// </summary>
        public Animator animator;

        /// <summary>
        /// Player speed variable
        /// </summary>
        public float moveSpeed = 5f;

        /// <summary>
        /// Variable for character model
        /// </summary>
        public Rigidbody2D rb;

        /// <summary>
        /// Stores movement value
        /// </summary>
        private Vector2 movement;

        private float horizontalMove = 0f;

        public float runSpeed = 40f;

        /// <summary>
        /// Update is called once per frame 
        /// </summary>
        void Update()
        {
            //animator speed 
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        /// <summary>
        /// Update on timer not frames
        /// </summary>
        void FixedUpdate()
        {
            //Movement
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
>>>>>>> 6d704a5 (PlayerAttack fix):Cops And Robbers/Assets/Scripts/PlayerScripts/PlayerMovement/PlayerMovement.cs
