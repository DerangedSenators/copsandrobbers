using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class AutoHostClient : NetworkBehaviour
    {
        [SerializeField] private NetworkManager networkManager;

        void Start()
        {
            if (Application.isBatchMode) //Headless Build for Server 
            {
                Debug.Log($"=== Server Build Starting ===");
                
            }
            else
            {
               Debug.Log($"<color=yellow>=== Client Build Starting ===</color>");
               networkManager.StartClient(); 
            }
        }
        public void JoinLocal()
        {
            networkManager.networkAddress = "localhost";
            networkManager.StartClient();
        }
    }
}
