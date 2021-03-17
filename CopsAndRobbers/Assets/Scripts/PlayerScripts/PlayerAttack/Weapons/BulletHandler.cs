using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class BulletHandler: NetworkBehaviour
    {
        public Rigidbody2D BulletRigidbody;

        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.name.Equals("Player(Clone)"))
            {
                collider.gameObject.GetComponent<BulletDetector>().CmdDepleteHealth();
            }
            CmdDestroyBullet();
        }

        [Command]
        private void CmdDestroyBullet()
        {
            NetworkServer.Destroy(BulletRigidbody.gameObject);
        }
        
    }
}