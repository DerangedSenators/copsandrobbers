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
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class Designed to handle Melee Attacks. Implemented from the legacy <include file='PlayerAttack.cs'/>
    /// </summary>
    /// @author Hanzalah Ravat
    public class Melee : AttackVector
    {
        protected override void OnMobileAttackButtonPressed()
        {
            _state = State.ATTACKING;
            DoAttack();
        }

        protected override void OnMobileAttackButtonReleased()
        {
            // Do nothing for now
        }
        
        protected override void DoAttack()
        {
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(Manager.GetAttackPosition, Manager.attackOffset, EnemyLayer);
            
            foreach (var enemy in enemiesHit.Select(hit => hit.GetComponent<PlayerHealth>()).Where(obj => obj != null).Where(obj => obj != this))
            {
                Manager.CmdMeleeAttack(enemy);
            }
        }
    }
}