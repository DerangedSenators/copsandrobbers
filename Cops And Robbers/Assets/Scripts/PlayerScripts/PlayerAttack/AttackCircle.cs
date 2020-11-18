using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class AttackCircle : MonoBehaviour
    {
        public PlayerAttack playerAttack;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = playerAttack.GetAttackPoint();
        }
    }
}