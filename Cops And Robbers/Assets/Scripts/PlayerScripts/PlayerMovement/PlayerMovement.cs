using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerMovement : MonoBehaviour
    {
        public Animator animator;   // reference the animator object within unity
        public float moveSpeed = 5f;    // Player speed variable
        public Rigidbody2D rigidBody;  // Variable for character model
        private Vector2 movement;   // Stores movement value
        public float runSpeed = 40f;
        //private float horizontalMove = 0f;

        // Update is called once per frame 
        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        // Update on timer not frames
        void FixedUpdate()
        {
            //Movement
            rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        public Vector3 GetPosition() 
        {
            return transform.position;
        }
    }
}
