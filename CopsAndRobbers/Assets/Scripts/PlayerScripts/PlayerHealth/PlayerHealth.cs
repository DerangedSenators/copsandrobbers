using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This script is responsible for the function of the health bar and damage
    /// 
    /// @authors Hanzalah Ravat, Hannah Elliman, Ashwin Jaimal
    /// </summary>
    public class PlayerHealth : NetworkBehaviour
    {
        public float maxHealth = 100;

        [SyncVar]
        public float currentHealth;

        public delegate void HealthChangedDelegate(float currentHealth, float maxHealth);
        public event HealthChangedDelegate eventHealthChanged;
        public HealthBar healthBar;

        /// <summary>
        /// If a player no longer has any health kill them
        /// </summary>
        public void Update()
        {
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Handle damage that a player takes
        /// </summary>
        /// <param name="damage">Amount of damage taken</param>
        [Server]
        public void Damage(float damage)
        {
            Debug.Log("Damaging");
            SetHealth(Mathf.Max(currentHealth - damage, 0));

        }

        /// <summary>
        /// Change the health value to whatever 
        /// </summary>
        /// <param name="value">Health value, changed based on damage taken</param>
        public void SetHealth(float value)
        {
            if(isLocalPlayer && (value < currentHealth) && ControlContext.Instance.Active)
                Vibration.Vibrate();    
            currentHealth = value;
            this.eventHealthChanged?.Invoke(currentHealth, maxHealth);
        }


        /// <summary>
        /// Will start players on full health once connected to the server.
        /// </summary>
        [Server]
        public override void OnStartServer() => SetHealth(maxHealth);

        /// <summary>
        /// Kills the player
        /// </summary>
        private void Die()
        {
            //TODO remove destroy and instead disable movement to allow for respawn
            Destroy(gameObject);
        }

    }
}