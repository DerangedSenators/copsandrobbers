using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Script that controls Player Movement
    /// </summary>
    /// @authors Nisath Mohammed
    /// @authors Hanzalah Ravat
    public class PlayerMovement : NetworkBehaviour
    {
        public Animator animator;       // reference the animator object within unity
        public float moveSpeed = 20f;    // Player speed variable 5
        public Rigidbody2D rigidBody;   // Variable for character model
        private Vector2 movement;       // Stores movement value
        public float runSpeed = 300f;    //40f
        private Vector2 touchOrigin = -Vector2.one;    //Used to store location of screen touch origin for mobile controls.

        //private float horizontalMove = 0f;

        /// Update is called once per frame 
        void Update()
        {
            if (isLocalPlayer)
            {
                #if UNITY_STANDALONE || UNITY_WEBPLAYER
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
                
                //Check if Input has registered more than zero touches
                if (Input.touchCount > 0)
                {
                    //Store the first touch detected.
                    Touch myTouch = Input.touches[0];

                    //Check if the phase of that touch equals Began
                    if (myTouch.phase == TouchPhase.Began)
                    {
                        //If so, set touchOrigin to the position of that touch
                        touchOrigin = myTouch.position;
                    }

                    //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
                    else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                    {
                        //Set touchEnd to equal the position of this touch
                        Vector2 touchEnd = myTouch.position;

                        //Calculate the difference between the beginning and end of the touch on the x axis.
                        float x = touchEnd.x - touchOrigin.x;

                        //Calculate the difference between the beginning and end of the touch on the y axis.
                        float y = touchEnd.y - touchOrigin.y;

                        //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                        touchOrigin.x = -1;

                        //Check if the difference along the x axis is greater than the difference along the y axis.
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                            //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                            movement.x = x > 0 ? 1 : -1;
                        else
                            //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                            movement.y = y > 0 ? 1 : -1;
                    }
                }

#endif //End of mobile platform dependendent compilation section started above with #elif
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
        }

        /// Update on timer not frames
        void FixedUpdate()
        {
            //Movement
            if (isLocalPlayer)
            {
                rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }

        public Vector3 GetPosition() 
        {
            return transform.position;
        }
    }
}
