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

using Cinemachine;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Singleton Class to provide access to the Virtual Camera
    /// </summary>
    public class VirtualCameraSingleton : MonoBehaviour
    {
        private static VirtualCameraSingleton _instance;
        public CinemachineVirtualCamera mVirtualCamera;
        public static VirtualCameraSingleton Instance { get { return _instance; } }
        private Transform target;

        public void HelloWorld()
        {
            //*Debug.Log($"Hello World!!!!");
        }

        private void Awake()
        {
            //*Debug.Log($"VirtualCamera is awake!");
            if (_instance != null && _instance != this)
            {
                //*Debug.Log($"Destroying instance");
                Destroy(this.gameObject);
            }
            else
            {
                //*Debug.Log($"Setting instance");
                _instance = this;
            }
        }
        public void assignFollowTransform(Transform toAssign)
        {
            //*Debug.Log($"Assigning transform...");
            mVirtualCamera.Follow = toAssign;
            //mVirtualCamera.LookAt = toAssign;
            //*Debug.Log("Assigned Transform to VCAM");
        }
    }
}