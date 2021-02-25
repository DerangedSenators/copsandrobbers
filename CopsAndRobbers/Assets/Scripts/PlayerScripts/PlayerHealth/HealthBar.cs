using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
*@author Peter
*/
namespace Me.DerangedSenators.CopsAndRobbers
{
    //This script is responsible for the function of the healthbar
    public class HealthBar : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerHealth health = null;
        [SerializeField] private Image healthBarImage = null;

        /// <summary>
        /// Change the health bar values
        /// </summary>
        private void OnEnable()
        {
            health.eventHealthChanged += HandleHealthChanged;
        }

        private void OnDisable()
        {
            health.eventHealthChanged -= HandleHealthChanged;
        }

        /// <summary>
        /// Change the health bar fill amount to match health value
        /// </summary>
        /// <param name="currentHealth">Current value of health</param>
        /// <param name="maxHealth">Max health value</param>
        private void HandleHealthChanged(float currentHealth, float maxHealth)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }
}

