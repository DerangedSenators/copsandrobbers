using System;
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
        public void Update()
        {
            Vector3 mousePosition = Manager.GetMousePosition();
            Vector3 aimPosition = (mousePosition - GunTransform.position).normalized;
            float angle = Mathf.Atan2(aimPosition.y, aimPosition.x) * Mathf.Rad2Deg;
            GunTransform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}