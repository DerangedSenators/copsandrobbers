using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerAttack : NetworkBehaviour
    {
        //variables
        private Vector3 mousePosition;  //position of mouse
        private Vector3 mouseDir;       //the direction of mouse click
        private Vector3 attackPosition; //the position of attack
        private Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default

        public LayerMask enemyLayer;    //select enemy layer
        public float damage = 10f;      //damage caused on each attack
        private State state;            //attack or normal states
        private float attackOffset;

        //Enum object State: contains the states player can be in. Used for attack animation.
        private enum State
        {
            NORMAL, 
            ATTACKING
        }

        private void Start()
        {
            state = State.NORMAL;
        }

        // Update is called once per frame 
        void Update()
        {
            switch (state) 
            {
                case State.NORMAL:
                    HandleAttack();
                    break;
                case State.ATTACKING:
                    HandleAttack();
                    break;
            }
        }

        //Attack on mouse-click if an enemy is in the direction of the mouse within an offset
        private void HandleAttack() 
        {
            mousePosition = GetMouseWorldPosition();
            Transform camera = Camera.main.transform;
            Vector3 playerCameraRelative = camera.InverseTransformPoint(transform.position);
            Vector3 playerMouseRelative ;
            mouseDir = (mousePosition - transform.position).normalized;
            Debug.Log("Transform X Positiion is: " + playerCameraRelative.x + " and MouseX position is: " + mousePosition.x );
            attackOffset = 0.6f;
            attackPosition = (playerCameraRelative + mouseDir * attackOffset);
            /**
            if (mousePosition.x > transform.position.x)
            {
                attackPosition = (transform.position + mouseDir * attackOffset);
                attackOffset = -0.6f;
            }
            else
            {
                attackPosition = (transform.position - mouseDir * attackOffset);
                attackOffset = 0.6f;
            }*/

            if (Input.GetMouseButtonDown(0))
            {
                state = State.ATTACKING;
                //perform attack animation here and set State.Normal 
                
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPosition, attackOffset, enemyLayer);
                foreach (Collider2D enemy in enemiesHit)
                {
                    enemy.GetComponent<PlayerHealth>().Damage(damage); //attack the enemy
                }
            }
        }
        
        /// <summary>
        /// Draw a circle around the player showing the attackRadius visually.
        /// </summary>
        public void OnDrawGizmosSelected()
        {
            if(attackPosition != null)
                Gizmos.DrawWireSphere(attackPosition, attackOffset);
        }

        //helper method: returns position of mouse pointer without z
        private Vector3 GetMouseWorldPosition()
        {
            /**
            Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
            vec.z = 0f;
            return vec;*/
            Vector2 mousePos = GetMouseWorldPositionV2();
            return new Vector3(mousePos.x,mousePos.y,0.0f);
        }

        private Vector2 GetMouseWorldPositionV2()
        {
            return Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        }
        
        //helper method: returns position of mouse with z axis
        private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        }

        public Vector3 GetAttackPoint() {
            return attackPosition;
        }
    }
}