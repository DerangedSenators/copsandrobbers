using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Camera Controller script
    /// </summary>
    public class CameraController : NetworkBehaviour
    {
        public Camera camera;

        private void Awake()
        {
            camera = Camera.main;
            camera.enabled = false;

        }

        public override void OnStartLocalPlayer()
        {
            camera.enabled = true;
        }
    }
}