using System;
using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers 
{ 
    /// <summary>
    /// This script is responsible for the respawn function
    /// 
    /// </summary>
    /// @authors Hannah Elliman, Piotr Krawiec
    public class PlayerRespawn : MonoBehaviour 
    {
        public PlayerHealth health;

        public GameObject FloatingText;
        
        private float countdownTimer;

        private bool countdown;

        public bool respawned;
        

        /// <summary>
        /// Initialise variables
        /// </summary>
        void Start()
        {
            countdown = false;
            countdownTimer = 0;
            respawned = false;
        }

        /// <summary>
        /// Check if the countdown on respawn is occuring
        /// </summary>
        void Update()
        {
            if (countdown)
            {
                Counting();
            }

            if (countdownTimer >= 2.5)
            {
                respawned = true;
                countdown = false;
                countdownTimer = 0;
                health.setIsAlive(true);
            }
        }

        
        
        /// <summary>
        /// When a player enters the circle collider start respawning
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter2D(Collider2D collider)
        {
            bool teamAlive = false;
            if (collider.gameObject.GetComponent<PlayerHealth>() != null)
            {
                teamAlive = collider.gameObject.GetComponent<PlayerHealth>().getIsAlive();    
            }
            
            //teamAlive = health.getIsAlive();
            
            if (GetComponent<PlayerHealth>().getIsAlive() == false && collider.gameObject.layer == gameObject.layer && teamAlive)
            {
                countdown = true;
                ShowFloatingText();
            }
        }

        /// <summary>
        /// When a player exits the collider stop the respawn and reset the countdown
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerExit2D(Collider2D collider)
        {
            countdownTimer = 0;
            countdown = false;
            RemoveFloatingText();
        }
        
        /// <summary>
        /// Start counting so respawn happens after a short wait
        /// </summary>
        private void Counting()
        {
            if (countdownTimer <= 2.5)
            {
                countdownTimer += 1 * Time.deltaTime;
            }
        }

        /// <summary>
        /// Set the respawn value 
        /// </summary>
        /// <param name="respawned">Boolean value to set the respawned value</param>
        public void setRespawn(bool respawned)
        {
            this.respawned = respawned;
        }

        /// <summary>
        /// Get the value of respawned
        /// </summary>
        /// <returns>Boolean value respawned</returns>
        public bool getRespawn()
        {
            return respawned;
        }
        
        /// <summary>
        /// Display a popup stating that the player is respawning
        /// </summary>
        void ShowFloatingText()
        {
            Vector3 vector3 = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z  - 2f);
            var text = Instantiate(FloatingText, vector3, Quaternion.identity, transform);
            text.GetComponent<TextMesh>().text = "Respawning";
        }

        /// <summary>
        /// Destroy the respawning popup
        /// </summary>
        public void RemoveFloatingText()
        {
            var go = GameObject.FindWithTag("Popup");
            Destroy(go);
        }

        
    }
}