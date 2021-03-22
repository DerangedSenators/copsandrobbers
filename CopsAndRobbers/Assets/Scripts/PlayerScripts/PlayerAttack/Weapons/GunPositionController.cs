using System;
using System.Net;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    /// Script to handle position of the gun on the screen
    /// </summary>
    /// @authors Hanzalah Ravat and Pitor Kraiwec 
    public class GunPositionController : MonoBehaviour
    {
        public Transform GunTransform;
        public WeaponManager Manager;
        public SpriteRenderer WeaponRenderer;
        public void Update()
        {
            Vector3 mousePosition = Manager.GetMousePosition();
            Vector3 aimPosition;
            if (ControlContext.Instance.Active)
            {
                aimPosition = ControlContext.Instance.AttackCircleStick.Direction;
            }
            else
            {
                aimPosition = (mousePosition - Manager.ThisPlayer.transform.position).normalized;
            }
            float angle = Mathf.Atan2(aimPosition.y, aimPosition.x) * Mathf.Rad2Deg;
            GunTransform.eulerAngles = new Vector3(0, 0, angle);
            GunTransform.position = new Vector3(Manager.GetAttackPoint(0.75f).x, Manager.GetAttackPoint(0.4f).y, 0);
            FlipSpriteDependingOnAxis();
        }
        
        private void FlipSpriteDependingOnAxis()
        {
            if (ControlContext.Instance.AttackCircleStick.Horizontal == 0 &&
                ControlContext.Instance.AttackCircleStick.Vertical == 0)
            {
                WeaponRenderer.flipY = false;
                return;
            }

            if (Manager.MouseXPositionRelativeToPlayer() == -1)
            {
                WeaponRenderer.flipX = false;
                WeaponRenderer.flipY = true;
            }
            else if (Manager.MouseXPositionRelativeToPlayer() == 1)
            {
                WeaponRenderer.flipY = false;
            }
        }
    }
}