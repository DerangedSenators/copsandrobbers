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

using System;
using Mirror;
using UnityEngine;

namespace DerangedSenators.CopsAndRobbers.Camera.Cinemachine
{
    /// <summary>
    ///     Script which defines the follow attribute for the Cinemachine Virtual Camera
    /// </summary>
    /// @author Hanzalah Ravat
    public class PlayerCameraContoller : NetworkBehaviour
    {
        public static Vector3 positionOnUpdate;
        public Transform playerTransform;
        private bool mod;

        private void Start()
        {
            if (isLocalPlayer)
                //*Debug.Log("This is a Local Player... Assigning VCAM");

                // VirtualCameraSingleton.Instance.mVirtualCamera.Follow = playerTransform;

                //VirtualCameraSingleton.Instance.HelloWorld();


                if (transform != null)
                {
                    //*Debug.Log($"Camera assigned");
                    //*Debug.Log($"Player transform: {playerTransform}");
                    //*Debug.Log($"Player transform X: {playerTransform.position.x}, Y: {playerTransform.position.y}");
                    // VirtualCameraSingleton.Instance.assignFollowTransform(playerTransform);
                }
            // VirtualCameraSingleton.Instance.assignFollowTransform(playerTransform.Find("weapon"));
        }

        private void FixedUpdate()
        {
            try
            {
                if (VirtualCameraSingleton.Instance.mVirtualCamera != null && !mod)
                {
                    VirtualCameraSingleton.Instance.mVirtualCamera.Follow = playerTransform;
                    //*Debug.Log("instance assinged: " + VirtualCameraSingleton.Instance.mVirtualCamera);
                    mod = true;
                }

                positionOnUpdate = VirtualCameraSingleton.Instance.mVirtualCamera.Follow.position;
            }
            catch (NullReferenceException exception)
            {
            }
        }
    }
}