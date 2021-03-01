using System.Linq;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    /// Class Designed to handle Melee Attacks. Implemented from the legacy <include file='PlayerAttack.cs'/>
    /// </summary>
    /// @author Hanzalah Ravat
    public class Melee : AttackVector
    {
        protected override void OnMobileAttackButtonPressed()
        {
            SetAttackParams();
            this._state = State.ATTACKING;
            DoAttack();
        }

        protected override void OnMobileAttackButtonReleased()
        {
            // Do nothing for now
        }

        private void SetAttackParams()
        {
            mousePosition = GetMouseWorldPosition(); // +new Vector3(-0.5f, -0.2f, 0);

            mouseDir = (mousePosition - transform.position).normalized;

            attackOffset = 0.8f;

            attackPosition = (transform.position + mouseDir * attackOffset);
        }

        protected override void DoAttack()
        {
            Debug.Log("Attacking");
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPosition, attackOffset, EnemyLayer);


            foreach (var enemy in enemiesHit.Select(hit => hit.GetComponent<PlayerHealth>()).Where(obj => obj != null).Where(obj => obj != this))
            {
                base.CmdAttack(enemy);
            }
        }
    }
}