using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class which manages attacking from a player
    /// </summary>
    /**
     * @authors Nisath Mohammed, Hanzalah Ravat, Hannah Elliman
     */
    public class PlayerAttack : NetworkBehaviour
    {
        //variables
        private Vector3 mousePosition;  //position of mouse
        private Vector3 mouseDir;       //the direction of mouse click
        private Vector3 attackPosition; //the position of attack
        private Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default

        public LayerMask enemyLayer;    //select enemy layer
        public int damage = 10;      //damage caused on each attack
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

        #region Client
        // Update is called once per frame 
        void Update()
        {
            if (isLocalPlayer)
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

        }
        #endregion

        //Attack on mouse-click if an enemy is in the direction of the mouse within an offset
        void HandleAttack() 
        {
            mousePosition = GetMouseWorldPosition(); // +new Vector3(-0.5f, -0.2f, 0);
            
            mouseDir = (mousePosition - transform.position).normalized;

            attackOffset = 0.8f;
            
            attackPosition = (transform.position + mouseDir * attackOffset);

            if (Input.GetMouseButtonDown(0)) // TODO Add support for Mobile Button here.
            {
                state = State.ATTACKING;
                //perform attack animation here and set State.Normal 
                DoAttacking();
            }
        }
        /// <summary>
        /// This method performs an attack rather than having HandleAttack complete it as the server does not have access to some resources that HandleAttack uses
        /// </summary>
        public void DoAttacking()
        {
            Debug.Log("Attacking");
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPosition, attackOffset, enemyLayer);


            foreach (var enemy in enemiesHit.Select(hit => hit.GetComponent<PlayerHealth>()).Where(obj => obj != null).Where(obj => obj !=this))
            {
                this.CmdAttack(enemy);
            }
        }

        [Command]
        public void CmdAttack(PlayerHealth enemy) {
            enemy.Damage(damage);
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
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        private Vector3 GetMouseWorldPosition()
        {
            
            Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
            vec.z = 0f;
            return vec;
        }
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        private Vector3 GetMouseWorldPosition()
        {
            Vector2 vec = ControlContext.Instance.AttackCircleStick.Direction;
            Vector3 vector3;
            vector3.x = vec.x;
            vector3.y = vec.y;
            vector3.z = 0f;
            return vec;
        }
        #endif
        
        //helper method: returns position of mouse with z axis
        private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        }

        public Vector3 GetAttackPoint() 
        {
            return attackPosition;
        }

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        public Vector3 GetAttackPoint(float offset)
        {
            return (transform.position + mouseDir * offset);
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        public Vector3 GetAttackPoint(float offset)
        {
            return (transform.position + new Vector3(ControlContext.Instance.AttackCircleStick.Horizontal,
                ControlContext.Instance.AttackCircleStick.Vertical, 0) * offset);
        }
#endif

        /// <summary>
        /// Return -1 if mouse is left, 1 if mouse is right or 0.
        /// </summary>
        /// <returns>Return -1 if mouse is left, 1 if mouse is right or 0.</returns>
        public int MouseXPositionRelativeToPlayer() 
        {
            #if UNITY_STANDALONE || UNITY_WEBPLAYER
            if(mousePosition.x < transform.position.x)
            {
                return -1;
            }
            else if (mousePosition.x > transform.position.x)
            {
                return 1;
            }
            return 0;
            #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            if (ControlContext.Instance.AttackCircleStick.Horizontal <= 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
            #endif
        }
    }
}