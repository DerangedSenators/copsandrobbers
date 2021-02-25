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
    /// </summary>
    public class PlayerHealth : NetworkBehaviour
    {
        public float maxHealth = 100;
       
        [SyncVar]
        public float currentHealth;

        public delegate void HealthChangedDelegate(float currentHealth, float maxHealth);
        public event HealthChangedDelegate eventHealthChanged;


        /// <summary>
        /// Handle health being changed
        /// </summary>
        /// <param name="currentHealth">Current value of health</param>
        /// <param name="maxHealth">Total amount of health</param>
        [ClientRpc]
        void RpcHealthChangedDelegate(float currentHealth, float maxHealth)
        {
            eventHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        /// <summary>
        /// Call Health changed on client
        /// </summary>
        /// <param name="currentHealth">Current value of health</param>
        /// <param name="maxHealth">Max health value</param>
        [Command]
        public void CmdHealthChangedDelegate(float currentHealth, float maxHealth)
        {
            Debug.Log("Changing Health");
            RpcHealthChangedDelegate(currentHealth, maxHealth);
        }

        /// <summary>
        /// Handle damage that a player takes
        /// </summary>
        /// <param name="damage">Amount of damage taken</param>
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
            currentHealth = value;
            this.eventHealthChanged?.Invoke(currentHealth, maxHealth);
            if (isServer)
            {
                RpcHealthChangedDelegate(currentHealth, maxHealth);
            }
            else {
                CmdHealthChangedDelegate(currentHealth, maxHealth);
            }
        }


        /// <summary>
        /// Will start players on full health once connected to the server.
        /// </summary>
        [Server]
        public override void OnStartServer() => SetHealth(maxHealth);

     
    }
}

   

    

