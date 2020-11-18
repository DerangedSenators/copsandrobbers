using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerAttack : MonoBehaviour
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
            Normal, Attacking
        }

        private void Start()
        {
            state = State.Normal;
        }

        // Update is called once per frame 
        void Update()
        {
            switch (state) 
            {
                case State.Normal:
                    HandleAttack();
                    break;
                case State.Attacking:
                    HandleAttack();
                    break;
            }
        }

        //Attack on mouse-click if an enemy is in the direction of the mouse within an offset
        private void HandleAttack() 
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = GetMouseWorldPosition();
                mouseDir = (mousePosition - transform.position).normalized;
                attackOffset = 0.6f;
                attackPosition = transform.position + mouseDir * attackOffset;

                state = State.Attacking;
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
            if (attackPosition == null)
            {
                return;
            } 
            Gizmos.DrawWireSphere(attackPosition, attackOffset);
        }

        //helper method: returns position of mouse pointer without z
        private Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        //helper method: returns position of mouse with z axis
        private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

    }
}