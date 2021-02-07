using System;
using Me.DerangedSenators.CopsAndRobbers;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Singleton class that can be used in Multiplayer games to retrieve aspects relating to the local player
    /// </summary>
    public class LocalPlayer : NetworkBehaviour
    {
        private static LocalPlayer _instance;

        public static LocalPlayer Instance { get { return _instance; } }

        public Transform playerTransform;
        /// <summary>
        /// Method to retrieve the player transform
        /// </summary>
        /// <returns> Gets the local player's Transform</returns>
        public Transform GetPlayerTransform() => playerTransform;
        

        /// <summary>
        /// This method sets the instance. This is to prevent non-local players from occupying the instance
        /// </summary>
        public void Start()
        {
            Debug.Log("LocalPlayer class is Awake!");
            if (isLocalPlayer)
            {
                Debug.Log($"This is a local player. Setting the instance for Local Player");
                if (_instance != null && _instance != this)
                {
                    Destroy(this.gameObject);
                } else {
                    _instance = this;
                }
            }
        }

        private void Update()
        {
            Debug.Log("Updating all Cameras");
            Camera[] allCameras = GetComponents<Camera>();
            foreach (var camera in allCameras)
            {
                camera.transform.position = playerTransform.position;
            }
        }
    }
}