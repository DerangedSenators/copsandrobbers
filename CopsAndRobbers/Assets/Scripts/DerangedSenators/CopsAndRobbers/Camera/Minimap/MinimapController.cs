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
using DerangedSenators.CopsAndRobbers.Camera.Cinemachine;
using UnityEngine;

namespace DerangedSenators.CopsAndRobbers.Camera.Minimap
{
    /// <summary>
    /// This class controls the minimap cinemachine camera
    /// </summary>
    /// @author Hanzalah Ravat
    public class MinimapController : MonoBehaviour
    {
        public UnityEngine.Camera minimapCamera;

        private void LateUpdate()
        {
            try
            {
                var newPosition = VirtualCameraSingleton.Instance.mVirtualCamera.Follow.position;
                newPosition.z = -50;
                minimapCamera.transform.position = newPosition;
                ////*Debug.Log($"The Position has been set to: {minimapCamera.transform.position.ToString()}");
            }
            catch (Exception e)
            {
                //*Debug.Log($"Exception occured when trying to run a late update : {e.Message}");
            }
        }
    }
}