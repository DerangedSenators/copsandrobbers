using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class designed to manage a player's weapons
    /// </summary>
    /// @author Hanzalah Ravat
    public class WeaponManager : NetworkBehaviour
    {
        /// <summary>
        /// The current weapon used by the player
        /// </summary>
        private GameObject _weapon;

        /// <summary>
        /// The Player's Enemy Layer Mask
        /// </summary>
        public LayerMask EnemyLayer;

        /// <summary>
        /// A list with the weapons available to the player
        /// </summary>
        public List<GameObject> WeaponInventory;

        /// <summary>
        /// This Player
        /// </summary>
        public Player ThisPlayer;

        private static WeaponManager localInstance;

        public static WeaponManager LocalInstance => localInstance;
        
        private Vector3 mousePosition;
        private Vector3 mouseDir;
        private Vector3 attackPosition;
        /// <summary>
        /// Get the Mouse Position
        /// </summary>
        /// <returns>The position of the mouse relative to the screen</returns>
        public  Vector3 GetMousePosition() => mousePosition;
        /// <summary>
        /// Get the Mouse Direction or attack stick direction on Mobile
        /// </summary>
        /// <returns>Vector3 with attack direction</returns>
        public  Vector3 GetMouseDir() => mouseDir;
        /// <summary>
        /// Gets the Attack Position
        /// </summary>
        public  Vector3 GetAttackPosition => attackPosition;

        public float attackOffset;

        private int currentIndex;

        public GameObject Bullet;
        
        public void SwitchWeapon(GameObject oldWeapon, GameObject newWeapon)
        {
            StartCoroutine(ChangeWeapon(oldWeapon,newWeapon));
        }
        
        private IEnumerator ChangeWeapon(GameObject oldWeapon, GameObject newWeapon)
        {
            // Destroy Current Weapon
            oldWeapon.SetActive(false);
            newWeapon.SetActive(true);
            _weapon = newWeapon;
            yield return null;
        }

        public override void OnStartLocalPlayer()
        {
            if(isLocalPlayer)
                localInstance = this;
            _weapon = WeaponInventory[0];
            currentIndex = 0;
            _weapon.SetActive(true);
            Debug.Log("Instance set");
        }

        #region Client
        private void Update()
        {
            if (isLocalPlayer)
            {
                setAttackParams();
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("Switching to Baton");
                    SwitchWeapon(_weapon,WeaponInventory[0]);
                    currentIndex = 0;
                } else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.E))
                { 
                    Debug.Log("Switching to Gun");
                    SwitchWeapon(_weapon,WeaponInventory[1]);
                    currentIndex = 1;

                }
            }
        }

        /// <summary>
        /// Sets the Attack Parameters such as MousePosition and MouseDir
        /// </summary>
        private void setAttackParams()
        {
            mousePosition = GetMouseWorldPosition(); // +new Vector3(-0.5f, -0.2f, 0);

            mouseDir = (mousePosition - transform.position).normalized;

            attackOffset = 0.8f;

            attackPosition = (transform.position + mouseDir * attackOffset);
        }
        #endregion

        public void FixedUpdate()
        {
            WeaponInventory[currentIndex].GetComponent<AttackVector>().HandleAttack();
        }
        //--- Helper Methods ---//

        /// <summary>
        /// Command to shoot over the Network
        /// </summary>
        [Command]
        public void CmdShoot(Vector3 mouseDir, Vector3 mousePosition, float bulletVelocity)
        {
            Debug.Log($"Projectile Speed is {bulletVelocity}");
            var projectile =  Instantiate(Bullet, transform.position, transform.rotation);
            projectile.transform.position += mouseDir;
            Vector3 bulletPosition = (mousePosition - projectile.transform.position).normalized;
            float angle = Mathf.Atan2(bulletPosition.y, bulletPosition.x) * Mathf.Rad2Deg;
            projectile.transform.eulerAngles = new Vector3(0, 0, angle);
            projectile.GetComponent<Rigidbody2D>().velocity = mouseDir.normalized * bulletVelocity;
            projectile.GetComponent<Rigidbody2D>().gravityScale = 0;
            Debug.Log("Shooting...");
            NetworkServer.Spawn(projectile);
        }

        /// <summary>
        /// Gets the Mouse Position with Z Axis
        /// </summary>
        /// <param name="screenPosition"> The Current position of the player within screen-context</param>
        /// <param name="worldCamera">The WorldView Camera</param>
        /// <returns>A Vector3 With the relative mouse position</returns>
        public  Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        }
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        public  Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
            vec.z = 0f;
            return vec;
        }
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
                public Vector3 GetMouseWorldPosition()
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
        public  Vector3 GetAttackPoint()
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
