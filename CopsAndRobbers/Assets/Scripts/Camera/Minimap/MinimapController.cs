using System;
using Cinemachine;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MinimapController : MonoBehaviour
    {
        public Camera minimapCamera;
        
        private void LateUpdate()
        {
            try
            {
                Vector3 newPosition = VirtualCameraSingleton.Instance.mVirtualCamera.Follow.position;
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