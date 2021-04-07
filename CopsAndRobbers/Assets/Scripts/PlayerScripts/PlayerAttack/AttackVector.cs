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
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    ///     Abstract class used for different weapons
    /// </summary>
    /// @author Hanzalah Ravat
    public abstract class AttackVector : NetworkBehaviour
    {
        /// <summary>
        ///     The LayerMask is used to detect collisions with an enemy
        /// </summary>
        public LayerMask EnemyLayer;

        /// <summary>
        ///     Damage caused from a single strike by this vector. Set as 10% by default but can be overridden as required
        /// </summary>
        protected int damageModifier = 10;

        protected State _state;

        private bool _buttonListenerSet;

        /// <summary>
        ///     The Weapon Manager managing the weapon contexts
        /// </summary>
        public WeaponManager Manager;

        /// <summary>
        ///     Enum object State: contains the states player can be in. Used for attack animation.
        /// </summary>
        protected enum State
        {
            NORMAL,
            ATTACKING
        }

        private class MobileButtonListener : IButtonListener
        {
            private readonly AttackVector _attack;

            public MobileButtonListener(AttackVector attacker)
            {
                _attack = attacker;
            }

            public void onButtonPressed()
            {
                if (_attack.isLocalPlayer)
                    // Handle Attack
                    _attack.OnMobileAttackButtonPressed();
            }

            public void onButtonReleased()
            {
                _attack.OnMobileAttackButtonReleased();
            }
        }

        /// <summary>
        ///     Action to be completed when the attack button is pressed on mobile
        /// </summary>
        protected abstract void OnMobileAttackButtonPressed();

        /// <summary>
        ///     Action to be completed when the attack button is released on mobile
        /// </summary>
        protected abstract void OnMobileAttackButtonReleased();

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        #region Client
        void Updatee()
        {
            Debug.Log($"Hi There! The Local Player is {isLocalPlayer}");
            if (isLocalPlayer)
            {
                Debug.Log("Running this function");
                HandleAttack();
            }

        }

        #endregion

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        private void FixedUpdate()
        {
            if (!_buttonListenerSet && isLocalPlayer)
                try
                {
                    ControlContext.Instance.AttackButton.AddListener(new MobileButtonListener(this));
                    _buttonListenerSet = true;
                }
                catch (NullReferenceException ex)
                {
                    // WaitOut
                }
        }
#endif


        /// <summary>
        ///     Method that checks if the attack button is pressed on desktop and then if true, invokes the DoAttack method
        /// </summary>
        public void HandleAttack()
        {
            if (Manager == null) Manager = WeaponManager.LocalInstance;

            DoAttack();
        }

        /// <summary>
        ///     This method performs the attack on the server
        /// </summary>
        protected abstract void DoAttack();
    }
}