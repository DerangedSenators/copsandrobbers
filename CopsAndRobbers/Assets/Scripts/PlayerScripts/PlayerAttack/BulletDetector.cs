using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Bullet Detector Script which can be attached to a prefab so that it can perform a health deplete action when a bullet enters the collider range
    /// </summary>
    /// @author Hanzalah Ravat
    public class BulletDetector : NetworkBehaviour
    {
        const int HealthDeplete = 5;
        
        public PlayerHealth Health;
        
        /// <summary>
        /// This event method is used to determine if the collider is a bullet type 
        /// </summary>
        /// <param name="bullet">The Collider</param>
        private void OnTriggerEnter2D(Collider2D bullet)
        {
            Debug.Log($"The Player has collided with {bullet.name}");
            if (bullet.gameObject.name == "Bullet")
            {
                CmdDepleteHealth();
            }
        }

        /// <summary>
        /// Depletes health once a bullet is hit
        /// </summary>
        [Command]
        public void CmdDepleteHealth()
        {
            Health.Damage(HealthDeplete);
        }
    }
}