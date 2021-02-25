using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script handles the health bar UI
/// </summary>
/// @author Piotr Krawiec
/// @author Hannah Elliman
namespace Me.DerangedSenators.CopsAndRobbers
{
    //This script is responible for the fucntion of the healthbar
    public class HealthBar : MonoBehaviour
    {
        public PlayerHealth health;
        public Image healthBarImage;

        public void Update()
        {
            healthBarImage.fillAmount = health.currentHealth / health.maxHealth;
        }
    }
}

