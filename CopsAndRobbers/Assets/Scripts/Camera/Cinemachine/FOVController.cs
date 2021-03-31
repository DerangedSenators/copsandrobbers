using System;
using Cinemachine;

using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This script is used to toggle the player FOV on button press. It will serve as a replacement for Minimap for the time being
    /// </summary>
    /// @author Hanzalah Ravat
    public class FOVController: MonoBehaviour
    {
        public float zoomOutView;
        public float zoomInView;
        public CinemachineVirtualCamera CameraLens;
        private bool active;
        public float t = 0.5f;
        public class MobileFOVController : IButtonListener
        {
            private readonly FOVController _controller;
            public void onButtonPressed()
            {
                _controller.active = true;
            }

            public void onButtonReleased()
            {
                _controller.active = false;
            }

            public MobileFOVController(FOVController controller)
            {
                _controller = controller;
            }
        }

        public void Start()
        {
            if (ControlContext.Instance.Active)
            {
                ControlContext.Instance.ZoomControl.AddListener(new MobileFOVController(this));
            }
        }

        public void FixedUpdate()
        {
            if (active)
            {
                CameraLens.m_Lens.FieldOfView = Mathf.Lerp(CameraLens.m_Lens.FieldOfView,zoomOutView,t);
            }
            else
            {
                CameraLens.m_Lens.FieldOfView = Mathf.Lerp(CameraLens.m_Lens.FieldOfView,zoomInView,t);;
            }

            if (Input.GetKeyDown(KeyCode.F) && !active)
            {
                active = true;
            } else if (Input.GetKeyDown(KeyCode.F))
            {
                active = false;
            }
        }
    }
}