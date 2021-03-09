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
            var bullet = (GameObject) Instantiate(Bullet, PlayerTransform.position, PlayerTransform.rotation);
            bullet.transform.position += Manager.GetMouseDir();
            Vector3 bulletPosition = (Manager.GetMousePosition() - bullet.transform.position).normalized;
            float angle = Mathf.Atan2(bulletPosition.y, bulletPosition.x) * Mathf.Rad2Deg;
            bullet.transform.eulerAngles = new Vector3(0, 0, angle);
            bullet.GetComponent<Rigidbody2D>().velocity = Manager.GetMouseDir().normalized * BulletVelocity;
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(bullet);
            CmdShoot(bullet);
        }

        /// <summary>
        /// Command to shoot over the Network
        /// </summary>
        [Command]
        public void CmdShoot(GameObject bullet)
        {
            NetworkServer.Spawn(bullet);
        }
        
    }
}