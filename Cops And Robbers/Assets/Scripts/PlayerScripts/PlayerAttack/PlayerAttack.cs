using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerAttack : MonoBehaviour
    {
        private enum State 
        { 
            Normal, Attacking
        }

        public Transform attackPoint;
        public Vector3 mouseDir; //the direction of mouse click
        private Vector3 attackPosition;
        private Vector3 mousePosition;
        public float attackRadius = 0.5f;
        public LayerMask enemyLayer;
        public float dmg = 20f;
        private State state;
        private float attackOffset;

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

        /// <summary>
        /// Cause damage to an enemyLayer object within the attackRadius. 
        /// </summary>
        /*public void Attack()
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            mouseDir = mousePosition - transform.position;
            float attackOffset = 3f;
            attackPosition = transform.position + mouseDir * attackOffset;
            Debug.Log("attack: " + mouseDir);

            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
            //Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(mouseDir, attackRadius, enemyLayer);
            foreach (Collider2D enemy in enemiesHit)
            {
                Debug.Log("someone is near"); 
                enemy.GetComponent<PlayerHealth>().Damage(dmg);
            }
        } */

        private void HandleAttack() 
        {
            if (Input.GetMouseButtonDown(0))
            {
                //perform attack animation and set State.Normal
                //Attack();
                mousePosition = GetMouseWorldPosition();
                mouseDir = (mousePosition - transform.position).normalized;
                attackOffset = 0.6f;
                attackPosition = transform.position + mouseDir * attackOffset;

                Debug.Log("attack: " + attackPosition);

                state = State.Attacking;

                
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPosition, attackOffset, enemyLayer);
                //Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(mouseDir, attackRadius, enemyLayer);
                foreach (Collider2D enemy in enemiesHit)
                {
                    Debug.Log("someone is near");
                    enemy.GetComponent<PlayerHealth>().Damage(dmg);
                }
            }
        }
         

        /// <summary>
        /// Draw a circle around the player showing the attackRadius visually.
        /// </summary>
        public void OnDrawGizmosSelected()
        {
            if (attackPoint.position == null)
                return;
            //Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
            Gizmos.DrawWireSphere(attackPosition, attackOffset);
        }


        //returns position of mouse pointer without z
        private Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        //returns position of mouse with z axis
        private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

    }
}