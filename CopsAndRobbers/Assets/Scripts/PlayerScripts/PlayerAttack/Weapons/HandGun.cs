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
            Manager.CmdShoot(BulletVelocity);
        }


        
    }
}