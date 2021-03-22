using System;
using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Me.DerangedSenators.CopsAndRobbers
{

    public class WeaponOffset : MonoBehaviour
    {
        public SpriteRenderer weaponSpriteRenderer;
        
        public WeaponManager playerAttack;

        public GameObject playerGameObject;

        bool flip;
        bool init = false;

        // Start is called before the first frame update
        void Start()
        {
            //playerAttack = cop.GetComponent<PlayerAttack>();
        }

        // Update is called once per frame
        void Update()
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
            {
                spriteRend.flipX = true;
            }
            else if (playerAttack.MouseXPositionRelativeToPlayer() == 1)
            {
                spriteRend.flipX = false;
            }
        }
    }
}