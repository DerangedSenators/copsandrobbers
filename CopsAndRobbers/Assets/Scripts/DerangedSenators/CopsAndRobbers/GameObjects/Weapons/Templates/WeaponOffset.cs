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
using DerangedSenators.CopsAndRobbers.GameObjects.Player;
using UnityEngine;

namespace DerangedSenators.CopsAndRobbers.GameObjects.Weapons.Templates
{
    public class WeaponOffset : MonoBehaviour
    {
        public SpriteRenderer weaponSpriteRenderer;

        public WeaponManager playerAttack;

        public GameObject playerGameObject;

        private bool flip;
        private bool init = false;

        // Start is called before the first frame update
        private void Start()
        {
            //playerAttack = cop.GetComponent<PlayerAttack>();
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                transform.position = new Vector3(playerAttack.GetAttackPoint(0.4f).x,
                    playerAttack.GetAttackPoint(0.4f).y, 0);

                FlipSpriteDependingOnAxis(weaponSpriteRenderer);
            }
            catch (NullReferenceException exception)
            {
                // There is a known NRE Here when the scene hasn't loaded as Mirror requires the player prefab and it's child scripts to be enabled beforehand
            }
        }

        private void FlipSpriteDependingOnAxis(SpriteRenderer spriteRend)
        {
            if (playerAttack.MouseXPositionRelativeToPlayer() == -1)
                spriteRend.flipX = true;
            else if (playerAttack.MouseXPositionRelativeToPlayer() == 1) spriteRend.flipX = false;
        }
    }
}