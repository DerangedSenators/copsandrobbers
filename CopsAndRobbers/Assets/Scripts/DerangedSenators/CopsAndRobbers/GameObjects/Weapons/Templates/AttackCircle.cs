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

using DerangedSenators.CopsAndRobbers.GameObjects.Player;
using UnityEngine;

namespace DerangedSenators.CopsAndRobbers.GameObjects.Weapons.Templates
{
    /// <summary>
    ///     Class which is used to determine the position of the AttackCircle in Melee Weapons
    /// </summary>
    /// @authors Nisath Mohamed and Hanzalah Ravat
    public class AttackCircle : MonoBehaviour
    {
        public WeaponManager playerAttack;

        private void Update()
        {
            //transform.position = playerAttack.GetAttackPoint();
            transform.position =
                new Vector3(playerAttack.GetAttackPoint(0.4f).x, playerAttack.GetAttackPoint(0.4f).y, 0);
        }
    }
}