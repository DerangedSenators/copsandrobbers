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

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        public void assignFollowTransform(Transform toAssign)
        {

            mVirtualCamera.Follow = toAssign;
            //mVirtualCamera.LookAt = toAssign;
            Debug.Log("Assigned Transform to VCAM");
        }
    }
}