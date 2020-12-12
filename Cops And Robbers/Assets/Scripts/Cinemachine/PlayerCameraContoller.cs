using System;
using System.Linq;
using Cinemachine;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Script which defines the follow attribute for the Cinemachine Virtual Camera
    /// </summary>
    public class PlayerCameraContoller : NetworkBehaviour
    {
        public Transform playerTransform;

        private void Start()
        {
            if (isLocalPlayer)
            {
                Debug.Log("This is a Local Player... Assigning VCAM");
                VirtualCameraSingleton.Instance.assignFollowTransform(playerTransform);
            }
        }
    }
}
