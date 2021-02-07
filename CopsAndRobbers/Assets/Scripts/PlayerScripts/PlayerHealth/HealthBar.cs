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

        private void OnEnable()
        {
            health.eventHealthChanged += HandleHealthChanged;
        }

        private void OnDisable()
        {
            health.eventHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}

