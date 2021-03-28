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