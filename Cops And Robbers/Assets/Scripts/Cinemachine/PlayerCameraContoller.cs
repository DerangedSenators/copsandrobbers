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
                
                
                VirtualCameraSingleton.Instance.mVirtualCamera.Follow = playerTransform;
                   
                
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
    }
}
