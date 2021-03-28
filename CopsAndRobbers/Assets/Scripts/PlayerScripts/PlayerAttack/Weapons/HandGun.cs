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
using System.Linq;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    /// Handgun Controller script
    /// </summary>
    /// @author Hanzalah Ravat
    public class HandGun : AttackVector
    {
        public GameObject Bullet;
        private bool isShooting;
        public Transform PlayerTransform;
        public Transform GunTransform;
        public float BulletVelocity;
        protected override void OnMobileAttackButtonPressed()
        {
            _state = State.ATTACKING;
            isShooting = true;
            DoAttack();
        }

        protected override void OnMobileAttackButtonReleased()
        {
            isShooting = false;
        }

        /// <summary>
        /// Fire bullets while the mouse is held
        /// </summary>
        protected override void DoAttack()
        {
            Debug.Log("Shooting");
            Vector3 direction = new Vector3(0,0,0);
            if (ControlContext.Instance.Active)
                direction = ControlContext.Instance.AttackCircleStick.Direction;
            Manager.CmdShoot(Manager.GetMouseDir(),Manager.GetMousePosition(),GunTransform.position,direction,BulletVelocity,ControlContext.Instance.Active);
        }


        
    }
}
