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
        public int maxHealth = 100;
       
        [SyncVar]
        public int currentHealth;

        public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);
        public event HealthChangedDelegate eventHealthChanged;

        #region ClientRpc
        [ClientRpc]
        private void RpcHealthChangedDelegate(int currentHealth, int maxHealth)
        {
            eventHealthChanged?.Invoke(currentHealth, maxHealth);

        }
        
        public void CmdDealDamage(int damage)
        {
            SetHealth(Mathf.Max(currentHealth - damage, 0));
        }
        
        private void SetHealth(int value)
        {
            currentHealth = value;
            this.eventHealthChanged?.Invoke(currentHealth, maxHealth);
            changeHealth();
        }
        #endregion

        #region Server
        [Server]
        public override void OnStartServer() => SetHealth(maxHealth);
        #endregion
        private void changeHealth() 
        {
            RpcHealthChangedDelegate(currentHealth, maxHealth);
        }
    }
}

   

    

