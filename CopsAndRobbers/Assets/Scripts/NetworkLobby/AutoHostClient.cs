using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

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
               networkManager.SceneManager.Start(); 
            }
        }
        public void JoinLocal()
        {
            networkManager.Client.ConnectAsync("localhost");
            networkManager.SceneManager.Start();         
        }
    }
}
