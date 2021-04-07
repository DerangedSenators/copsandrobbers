/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */


using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DerangedSenators.CopsAndRobbers.Screens.MainMenu
{
    ///<summary>For buttons that lead to the main menu, also disables any network connection to prevent sudden attempts to reconnect.</summary>
    ///@author Elliot Willis and Hannah Elliman
    public class LoadMainMenu : MonoBehaviour
    {
        [SerializeField] public NetworkManager networkManager;

        private void Start()
        {
            networkManager = NetworkManager.singleton;
        }

        public void Load()
        {
            networkManager.StopClient();
            SceneManager.LoadScene("MainMenu");
        }
    }
}