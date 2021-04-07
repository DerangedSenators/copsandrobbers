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
    ///     This script is used to toggle the player FOV on button press. It will serve as a replacement for Minimap for the
    ///     time being
    /// </summary>
    /// @author Hanzalah Ravat
    public class FOVController : MonoBehaviour
    {
        public float zoomOutView;
        public float zoomInView;
        public CinemachineVirtualCamera CameraLens;
        public float t = 0.5f;
        private bool active;

        public void Start()
        {
            if (ControlContext.Instance.Active)
                ControlContext.Instance.ZoomControl.AddListener(new MobileFOVController(this));
        }

        public void FixedUpdate()
        {
            if (active)
            {
                CameraLens.m_Lens.FieldOfView = Mathf.Lerp(CameraLens.m_Lens.FieldOfView, zoomOutView, t);
            }
            else
            {
                CameraLens.m_Lens.FieldOfView = Mathf.Lerp(CameraLens.m_Lens.FieldOfView, zoomInView, t);
                ;
            }

            if (Input.GetKeyDown(KeyCode.F) && !active)
                active = true;
            else if (Input.GetKeyUp(KeyCode.F)) active = false;
        }

        public class MobileFOVController : IButtonListener
        {
            private readonly FOVController _controller;

            public MobileFOVController(FOVController controller)
            {
                _controller = controller;
            }

            public void onButtonPressed()
            {
                _controller.active = true;
            }

            public void onButtonReleased()
            {
                _controller.active = false;
            }
        }
    }
}