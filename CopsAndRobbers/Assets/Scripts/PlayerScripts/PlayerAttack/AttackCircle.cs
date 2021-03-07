using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers.Weapons;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class which is used to determine the position of the AttackCircle in Melee Weapons
    /// </summary>
    /// @authors Nisath Mohamed and Hanzalah Ravat
    public class AttackCircle : MonoBehaviour
    {
        public WeaponManager playerAttack;
        
        void Update()
        {
            //transform.position = playerAttack.GetAttackPoint();
            transform.position = new Vector3(playerAttack.GetAttackPoint(0.4f).x, playerAttack.GetAttackPoint(0.4f).y, 0);
        }
    }
}