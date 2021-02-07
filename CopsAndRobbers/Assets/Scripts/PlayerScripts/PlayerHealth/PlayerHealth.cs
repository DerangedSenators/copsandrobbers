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
       [Header("Settings")]
       [SerializeField] public int maxHealth = 100;
       [SerializeField] public int damagePerPress = 10;
       
        [SyncVar]
        public int currentHealth;

        public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);
        public event HealthChangedDelegate eventHealthChanged;

        [ClientRpc]
        private void RpcHealthChangedDelegate(int currentHealth, int maxHealth)
        {
            eventHealthChanged?.Invoke(currentHealth, maxHealth);

        }

        #region Server
        [Server]
        private void SetHealth(int value)
        {
            currentHealth = value;
            this.eventHealthChanged?.Invoke(currentHealth, maxHealth);
            RpcHealthChangedDelegate(currentHealth, maxHealth);
        }

        public override void OnStartServer() => SetHealth(maxHealth);

        [Command]
        private void CmdDealDamage() => SetHealth(Mathf.Max(currentHealth - damagePerPress, 0));

        #endregion

        #region Client
        [ClientCallback]
        private void Update()
        {
            if (!hasAuthority) { return; }

            if (!Keyboard.current.spaceKey.wasPressedThisFrame) { return; }

            CmdDealDamage();
        }
        #endregion

    }
}

   

    

