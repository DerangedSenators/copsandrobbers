using System;
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
    /// @authors Hanzalah Ravat, Hannah Elliman, Ashwin Jaimal, Piotr Krawiec, Nisath Mohammed
    /// </summary>
    public class PlayerHealth : NetworkBehaviour
    {
        public float maxHealth;

        [SyncVar]
        public float currentHealth;

        private bool isAlive;

        public delegate void HealthChangedDelegate(float currentHealth, float maxHealth);
        public event HealthChangedDelegate eventHealthChanged;
        public HealthBar healthBar;
        public PlayerRespawn spawner;
        public MoneyManager moneyM;
        

        /// <summary>
        /// Initialise variables
        /// </summary>
        private void Start()
        {
            isAlive = true;
            maxHealth = 100;
        }

        /// <summary>
        /// If a player no longer has any health kill them
        /// </summary>
        public void Update()
        {
            if (moneyM == null) 
            {
                try
                {
                    moneyM = GetComponent<MoneyManager>();
                }
                catch (NullReferenceException ex)
                {
                    // Do nothing as there is a null ref exception here.
                }
            }
            
            if (currentHealth <= 0)
            {
                Die();
            }

            if (spawner.respawned)
            {
                CmdRespawn();
                spawner.setRespawn(false);
                spawner.RemoveFloatingText();
                Respawn();
            }
            
            RefreshRespawn();
        }

        /// <summary>
        /// Handle damage that a player takes
        /// </summary>
        /// <param name="damage">Amount of damage taken</param>
        [Server]
        public void Damage(float damage)
        {
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
            disableComponents();
            isAlive = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        /// <summary>
        /// Respawn function to change health across the server
        /// </summary>
        [Command]
        public void CmdRespawn()
        {
            SetHealth(50);
        }

        /// <summary>
        /// Respawn function to change health across the server
        /// </summary>
        [Command]
        public void CmdRespawnForNewRound()
        {
            SetHealth(100);
            //TODO verify the method is only being called for new round.
        }
        
        /// <summary>
        /// Enable components and subtract money when a player is respawned
        /// </summary>
        private void Respawn()
        {
            enableComponents();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            moneyM.SubtractMoney(gameObject.GetComponent<Player>().GetTeamId());
        }
        
        /// <summary>
        /// Enable components and subtract money when a player is respawned
        /// </summary>
        public void RespawnForNewRound()
        {
            Debug.Log("trying to enable componests and set is alive");
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            enableComponents();
            setIsAlive(true);
            
        }

        public void NormalizeRotation()
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
        

        /// <summary>
        /// Disable components and rotate player to appear dead
        /// </summary>
        private void disableComponents()
        {
            gameObject.GetComponent<WeaponManager>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.rotation = Quaternion.Euler(0,0,90);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        /// <summary>
        /// Enable components and rotate player upright
        /// </summary>
        public void enableComponents()
        {
            gameObject.GetComponent<WeaponManager>().enabled = true;
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("Enabling Components");
        }

        /// <summary>
        /// Get the boolean variable isAlive
        /// </summary>
        /// <returns>isAlive: is the player alive</returns>
        public bool getIsAlive()
        {
            return isAlive;
        }

        /// <summary>
        /// Set the boolean variable isAlive
        /// </summary>
        /// <param name="isAlive">Boolean value to change isAlive</param>
        public void setIsAlive(bool isAlive)
        {
            this.isAlive = isAlive;
        }


        public void RefreshRespawn()
        {
            
            if (TimeManager.ShouldRefreshRespawn() )
            {
                Debug.Log("Attempt to refresh spawns");
                currentHealth = 100;
                enableComponents();
                isAlive = true;
                TimeManager.SetIsRefreshSpawn(false);
                
                //CmdRespawn();
                //Respawn();
                //spawner.setRespawn(false);
                //currentHealth = 100;
                //spawner.RemoveFloatingText();
                
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                CmdRespawnForNewRound();
            }
        }
    }
}
