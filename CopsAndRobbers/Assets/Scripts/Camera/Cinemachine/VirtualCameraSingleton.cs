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