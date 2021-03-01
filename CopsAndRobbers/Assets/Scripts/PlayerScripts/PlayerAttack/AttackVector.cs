using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Abstract class used for different weapons
    /// </summary>
    /// @author Hanzalah Ravat
    public abstract class AttackVector : NetworkBehaviour
    {
        protected Vector3 mousePosition;
        protected Vector3 mouseDir;
        protected Vector3 attackPosition;
        private Vector3 _offset = Vector3.up;

        protected float attackOffset;
        /// <summary>
        /// The LayerMask is used to detect collisions with an enemy
        /// </summary>
        public LayerMask EnemyLayer;

        /// <summary>
        /// Damage caused from a single strike by this vector. Set as 10% by default but can be overridden as required
        /// </summary>
        protected int damageModifier = 10;

        protected State _state;

        private bool _buttonListenerSet = false;

        /// <summary>
        /// Enum object State: contains the states player can be in. Used for attack animation.
        /// </summary>
        protected enum State
        {
            NORMAL,
            ATTACKING
        }

        private class MobileButtonListener : IButtonListener
        {
            private AttackVector _attack;

            public MobileButtonListener(AttackVector attacker)
            {
                _attack = attacker;
            }

            public void onButtonPressed()
            {
                if (_attack.isLocalPlayer)
                {
                    // Handle Attack
                    _attack.OnMobileAttackButtonPressed();
                }
            }

            public void onButtonReleased()
            {
                _attack.OnMobileAttackButtonReleased();
            }
        }

        /// <summary>
        /// Action to be completed when the attack button is pressed on mobile
        /// </summary>
        protected abstract void OnMobileAttackButtonPressed();

        /// <summary>
        /// Action to be completed when the attack button is released on mobile
        /// </summary>
        protected abstract void OnMobileAttackButtonReleased();

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        #region Client

        void Update()
        {
            if (isLocalPlayer)
            {
                switch (_state)
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

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        private void FixedUpdate()
        {
            if (!attackListenerSet && isLocalPlayer)
            {
                try
                {
                    ControlContext.Instance.AttackButton.AddListener(new MobileButtonListener(this));
                    attackListenerSet = true;
                }
                catch (NullReferenceException ex)
                {
                    // WaitOut
                }
            }
        }
#endif

        /// <summary>
        /// Method that checks if the attack button is pressed on desktop and then if true, invokes the DoAttack method
        /// </summary>
        protected virtual void HandleAttack()
        {
            if (Input.GetMouseButtonDown(0))
                DoAttack();
        }

        /// <summary>
        /// This method performs the attack on the server
        /// </summary>
        protected abstract void DoAttack();

        [Command]
        protected void CmdAttack(PlayerHealth enemy)
        {
            enemy.Damage(damageModifier);
        }
        
        //--- Helper Methods ---//
        /// <summary>
        /// Gets the Mouse Position with Z Axis
        /// </summary>
        /// <param name="screenPosition"> The Current position of the player within screen-context</param>
        /// <param name="worldCamera">The WorldView Camera</param>
        /// <returns>A Vector3 With the relative mouse position</returns>
        protected Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        }
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        protected Vector3 GetMouseWorldPosition()
        {

            Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
            vec.z = 0f;
            return vec;
        }
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
                protected Vector3 GetMouseWorldPosition()
                {
                    Vector2 vec = ControlContext.Instance.AttackCircleStick.Direction;
                    Vector3 vector3;
                    vector3.x = vec.x;
                    vector3.y = vec.y;
                    vector3.z = 0f;
                    return vec;
                }
        #endif
        /// <summary>
        /// Gets the attack point
        /// </summary>
        /// <returns>The attack point</returns>
        public Vector3 GetAttackPoint()
        {
            return attackPosition;
        }

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        /// <summary>
        /// Gets an attack point with a provided offset
        /// </summary>
        /// <param name="offset">The Offset</param>
        /// <returns> The AttackPoint with the offset applied</returns>
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
            if (mousePosition.x < transform.position.x)
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