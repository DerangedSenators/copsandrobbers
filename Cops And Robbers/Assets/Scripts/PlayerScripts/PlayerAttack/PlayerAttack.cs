using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerAttack : NetworkBehaviour
    {
        //variables
        private Vector3 mousePosition;  //position of mouse
        private Vector3 mouseDir;       //the direction of mouse click
        private Vector3 attackPosition; //the position of attack
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
            mouseDir = (mousePosition - transform.position).normalized;
            attackOffset = 0.6f;
            attackOffset = 2f;
            attackPosition = transform.position + mouseDir * attackOffset;
            //attackPosition = transform.position;


            //Debug.Log("Inputmouse: " + Input.mousePosition);
            //Debug.Log("other: " + Mouse.current.position.ReadValue());
            



            if (Input.GetMouseButtonDown(0))
            {
                state = State.ATTACKING;
                //perform attack animation here and set State.Normal 

                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPosition, attackOffset, enemyLayer);
                //Collider2D[] enemiesHit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 2), 0f);

                
                //Collider2D[] enemiesHit;
               // Debug.Log(Mouse.current.position.x.normalizeMax);
               /*
                if (Mouse.current.position.x.ReadValue() >= transform.position.x)
                {
                    Debug.Log("Mouse.current.position.x.ReadValue(): " + Mouse.current.position.x.ReadValue() + ", > object pos x: " + transform.position.x);
                    enemiesHit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 2), 0f);
                }
                else
                {
                    Debug.Log("Mouse.current.position.x.ReadValue(): " + Mouse.current.position.x.ReadValue() + ", < object pos x: " + transform.position.x);
                    enemiesHit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 2), 0f);
                }
                
                */
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
            if (attackPosition == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(attackPosition, attackOffset);
            //Gizmos.DrawWireCube(transform.position, new Vector3(2, 2));
        }

        //helper method: returns position of mouse pointer without z
        private Vector3 GetMouseWorldPosition()
        {
            //Input.mousePosition
            //Mouse.current.position.ReadValue()
            //Vector3 mousePositionNewSystem = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f);
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            //Vector3 vec = GetMouseWorldPositionWithZ(mousePositionNewSystem, Camera.main);
            vec.z = 0f;
            return vec;
        }

        //helper method: returns position of mouse with z axis
        private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            //return screenPosition;
            return worldPosition;
        }

        public Vector3 GetAttackPoint() {
            attackPosition = transform.position + mouseDir * attackOffset;
            return attackPosition;
        }
    }
}