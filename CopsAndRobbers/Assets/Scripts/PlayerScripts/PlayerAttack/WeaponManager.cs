using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class designed to manage a player's weapons
    /// </summary>
    /// @author Hanzalah Ravat and Nisath Mohamed Nasar
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

        private bool listenerSet = false;
        
        /// <summary>
        /// The game object (from prefab) that will handle Audio Sources
        /// </summary>
        public GameObject sfxHandler;
        /// <summary>
        /// The melee attack sound in wav format.
        /// </summary>
        public AudioClip meleeAttackClip;
        /// <summary>
        /// This audio source is to be assigned with the clip to sfxHandler.
        /// </summary>
        private AudioSource meleeAudioSource;
        /// <summary>
        /// The melee attack sound in wav format.
        /// </summary>
        public AudioClip gunShotClip;
        /// <summary>
        /// This audio source is to be assigned with the clip to sfxHandler.
        /// </summary>
        private AudioSource gunShotAudioSource;


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

        public class MobileWeaponSwitchHandler : IButtonListener
        {
            private WeaponManager _manager;
            public MobileWeaponSwitchHandler(WeaponManager manager)
            {
                _manager = manager;
            }

            public void onButtonPressed()
            {
                if (_manager.isLocalPlayer)
                {
                    // Handle Attack
                    switch (_manager.currentIndex)
                    {
                        case 1:
                            _manager.currentIndex = 0;
                            break;
                        case 0:
                            _manager.currentIndex = 1;
                            break;
                    }
                    _manager.SwitchWeapon(_manager._weapon,_manager.WeaponInventory[_manager.currentIndex]);
                }
            }

            public void onButtonReleased()
            {
                // Do Nothing
            }
        }
        
        public class MobileAttackButtonListener : IButtonListener
        {
            private WeaponManager _manager;
            public MobileAttackButtonListener(WeaponManager manager)
            {
                _manager = manager;
            }

            public void onButtonPressed()
            {
                _manager.WeaponInventory[_manager.currentIndex].GetComponent<AttackVector>().HandleAttack();
            }

            public void onButtonReleased()
            {
                // Do Nothing
            }
        }

        public void OnEnable()
        {
            if(isLocalPlayer)
                localInstance = this;
            _weapon = WeaponInventory[0];
            currentIndex = 0;
            _weapon.SetActive(true);

        }

        #region Client
        private void Update()
        {
            try
            {
                if (isLocalPlayer)
                {
                    setAttackParams();
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Q))
                    {
                        Debug.Log("Switching to Baton");
                        SwitchWeapon(_weapon, WeaponInventory[0]);
                        currentIndex = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Switching to Gun");
                        SwitchWeapon(_weapon, WeaponInventory[1]);
                        currentIndex = 1;

                    }
                }
            }
            catch (NullReferenceException ex)
            {
                // NRE is thrown when Scene isn't active. This is a known event and is an unfortunate issue with Unity itself
            }
            #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            if (!listenerSet)
            {
                try
                {
                    ControlContext.Instance.WeaponSwitchButton.AddListener(
                        new MobileWeaponSwitchHandler(this));
                    ControlContext.Instance.AttackButton.AddListener(
                        new MobileAttackButtonListener(this));
                    listenerSet = true;
                }
                catch (NullReferenceException ex)
                {
                    // Context has not yet been established. Try again in the next frame.
                }
            }
            #endif
        }

        /// <summary>
        /// Sets the Attack Parameters such as MousePosition and MouseDir
        /// </summary>
        private void setAttackParams()
        {
            mousePosition = GetMouseWorldPosition(); // +new Vector3(-0.5f, -0.2f, 0);

            //#if UNITY_STANDALONE || UNITY_WEBPLAYER
            mouseDir = (mousePosition - transform.position).normalized;
            //#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            //mouseDir = mousePosition;
            //#endif
            attackOffset = 0.8f;

            attackPosition = (transform.position + mouseDir * attackOffset);
        }
        #endregion


        public void FixedUpdate()
        {
            #if UNITY_STANDALONE || UNITY_WEBPLAYER
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                WeaponInventory[currentIndex].GetComponent<AttackVector>().HandleAttack();
            }
            #endif
            if (meleeAudioSource == null)
            {
                meleeAudioSource = gameObject.AddComponent<AudioSource>();
                meleeAudioSource.clip = meleeAttackClip;    
            }

            if (gunShotAudioSource == null)
            {
                gunShotAudioSource = gameObject.AddComponent<AudioSource>();
                gunShotAudioSource.clip = gunShotClip;
            }
        }
        
        //--- Helper Methods ---//

        /// <summary>
        /// Command to shoot over the Network
        /// </summary>
        [Command]
        public void CmdShoot(Vector3 mouseDir, Vector3 mousePosition, Vector3 weaponTransform,Vector3 direction,float bulletVelocity,bool onMobile)
        {
            var projectile =  Instantiate(Bullet, weaponTransform, transform.rotation);

            RPCPlayGunShotSound();
            
            Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            if (onMobile) // Setup for Mobile
            {
                if (direction.x == 0 && direction.y == 0) // If the stick is idle
                {
                    direction.x = 1;
                }
                projectile.transform.position += direction;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                projectile.transform.eulerAngles = new Vector3(0,0,angle);;
                projectileRigidBody.velocity = direction.normalized * bulletVelocity;
            }
            else // Setup for Standalone Desktop
            {            
                projectile.transform.position += mouseDir;
                Vector3 bulletPosition = ( mousePosition - projectile.transform.position).normalized;
                float angle = Mathf.Atan2(bulletPosition.y, bulletPosition.x) * Mathf.Rad2Deg;
                projectileRigidBody.velocity = mouseDir.normalized * bulletVelocity;

            }

            projectileRigidBody.gravityScale = 0;
            NetworkServer.Spawn(projectile);
        }
        
        
        [Command]
        public void CmdMeleeAttack(PlayerHealth enemy)
        {
            enemy.Damage(10);
            RPCPlayMeleeSound();
        }

        /// <summary>
        /// Play the melee attack sound once per call to the method.
        /// </summary>
        [ClientRpc]
        public void RPCPlayMeleeSound()
        {
            meleeAudioSource.PlayOneShot(meleeAttackClip);
        }
        
        /// <summary>
        /// Play the gun shot sound once per call to the method.
        /// </summary>
        [ClientRpc]
        public void RPCPlayGunShotSound()
        {
            gunShotAudioSource.PlayOneShot(gunShotClip);
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
                    vector3.x = ControlContext.Instance.AttackCircleStick.Horizontal;
                    vector3.y = ControlContext.Instance.AttackCircleStick.Vertical;
                    vector3.z = 0f;
                    return vector3;
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
            if (ControlContext.Instance.AttackCircleStick.Horizontal == 0 &&
                ControlContext.Instance.AttackCircleStick.Vertical == 0)
            {
                return (transform.position + new Vector3(1,
                    0, 0) * offset);
            }
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
