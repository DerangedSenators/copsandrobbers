using System.Collections;
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