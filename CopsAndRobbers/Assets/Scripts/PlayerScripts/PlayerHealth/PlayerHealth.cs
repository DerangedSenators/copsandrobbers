/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

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
    /// </summary> 
    /// @authors Hanzalah Ravat, Hannah Elliman, Ashwin Jaimal, Piotr Krawiec, Nisath Mohammed 
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
                    moneyM = FindObjectOfType<MoneyManager>().GetComponent<MoneyManager>(); 
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
                Debug.Log("if spawner.respawner"); 
                CmdRespawn(); 
                spawner.setRespawn(false); 
                spawner.RemoveFloatingText(); 
                Respawn(); 
                Debug.Log("if spawner.respawner end"); 
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
            SetComponents(false); 
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
            SetComponents(true); 
            gameObject.GetComponent<CircleCollider2D>().enabled = false; 
            Debug.Log("Attempt to subtract money: teamid: " +gameObject.GetComponent<Player>().GetTeamId()); 
            moneyM.SubtractMoney(gameObject.GetComponent<Player>().GetTeamId()); 
        } 
         
         
        public void NormalizeRotation() 
        { 
            gameObject.transform.rotation = Quaternion.Euler(0,0,0); 
        } 
         
        
        /// <summary>
        /// Set the component status to either make player alive or dead depending on their alive status
        /// </summary>
        /// <param name="status">True if alive and False if Dead</param>
        private void SetComponents(bool status)
        {
            // TODO Make a Command to do this instead for server authority
            gameObject.GetComponent<WeaponManager>().enabled = status; 
            gameObject.GetComponent<PlayerMovement>().enabled = status; 
            gameObject.GetComponent<Animator>().enabled = status; 
            gameObject.GetComponent<BoxCollider2D>().enabled = status;
            if (status)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            gameObject.transform.GetChild(1).gameObject.SetActive(status);
            if (status)
            {
                Debug.Log("Enabling Components");
            }
            else
            {
                Debug.Log("Disabling Components");
            }
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
                SetComponents(true); 
                isAlive = true; 
                TimeManager.SetIsRefreshSpawn(false); 
                gameObject.GetComponent<CircleCollider2D>().enabled = false; 
                CmdRespawnForNewRound(); 
            } 
        } 
    } 
} 
