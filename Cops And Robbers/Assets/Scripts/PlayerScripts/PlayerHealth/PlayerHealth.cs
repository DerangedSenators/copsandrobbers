using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;



namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This script is responsible for the function of the health bar and damage
    /// </summary>
    public class PlayerHealth : NetworkBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public HealthBar healthBar;
        
        /// <summary>
        /// At the start of the project the player's health will equal to the max health
        /// </summary>
        public void Start()
        {
            currentHealth = maxHealth;
            if (healthBar != null)
            {
                healthBar.SetMaxHealth(maxHealth);
            }
        }

        /// <summary>
        /// This function checks if a user Used Space if it does the player will take 1.5 dmg
        /// </summary>
        public void Update()
        {
            //If players health reaches 0 It is removed form the scene
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Server-Callable Function which can be used to handle player damage globally.
        /// </summary>
        /// <param name="damage">Amount of damage taken, to update health bar</param>
        [Server]
        public void Damage(float damage)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);
        }

        /// <summary>
        /// This object is destroyed once health is 0.
        /// </summary>
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

   

    

