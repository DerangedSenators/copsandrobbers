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