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
        private bool mod = false;
        public static Vector3 positionOnUpdate;
        private void Start()
        {
            if (IsLocalPlayer)
            {
                Debug.Log("This is a Local Player... Assigning VCAM");
                
                
               // VirtualCameraSingleton.Instance.mVirtualCamera.Follow = playerTransform;
                   
                
                //VirtualCameraSingleton.Instance.HelloWorld();

                
                if(transform != null)
                {
                    
                    Debug.Log($"Camera assigned");
                    Debug.Log($"Player transform: {playerTransform}");
                    Debug.Log($"Player transform X: {playerTransform.position.x}, Y: {playerTransform.position.y}");
                   // VirtualCameraSingleton.Instance.assignFollowTransform(playerTransform);
                }
                // VirtualCameraSingleton.Instance.assignFollowTransform(playerTransform.Find("weapon"));
            }
        }

        private void FixedUpdate()
        {
            if (VirtualCameraSingleton.Instance.mVirtualCamera != null && !mod)
            {
                VirtualCameraSingleton.Instance.mVirtualCamera.Follow = playerTransform;
                Debug.Log("instance assigned: " + VirtualCameraSingleton.Instance.mVirtualCamera);
                mod = true;
            }
            positionOnUpdate = VirtualCameraSingleton.Instance.mVirtualCamera.Follow.position;

        }
    }
}
