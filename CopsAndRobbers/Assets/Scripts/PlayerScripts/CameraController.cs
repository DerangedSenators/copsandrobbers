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

        public static GameManager mGameManager;
        public CinemachineVirtualCamera mVirtualCamera;
        public Transform playerPrefab;
        private void Start()
        {
            if (mGameManager == null)
            {
                
            }

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