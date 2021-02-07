using System;
using Cinemachine;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Camera Controller script
    /// </summary>
    public class CameraController : NetworkBehaviour
    {

        public CinemachineVirtualCamera mVirtualCamera;
        public Transform playerPrefab;
        public static Vector3 positionOnUpdate;
        private void Start()
        {
            mVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public override void OnStartLocalPlayer()
        {
            if (isLocalPlayer)
            {
                mVirtualCamera.m_Follow = playerPrefab;
            }
        }
        
    }
}