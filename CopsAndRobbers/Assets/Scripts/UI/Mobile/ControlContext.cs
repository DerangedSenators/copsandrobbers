using System;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This is a Singleton Class that can be used by other classes (Prefab Scripts) to access Mobile UI objects. It also dictates whether or not they are displayed on the screen
    /// </summary>
    public class ControlContext: MonoBehaviour
    {
        public Joystick MovementStick;
        public Joystick AttackCircleStick;
        public GameObject ControlCanvas;
        private bool isActive;
        public bool Active => isActive;
        
        private static ControlContext _instance;
        public static ControlContext Instance => _instance;

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
            isEnabled();
            
        }
        
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        private void isEnabled()
        {
            ControlCanvas.SetActive(false);
            isActive = false;
        }
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        private void isEnabled()
        {
            ControlCanvas.SetActive(true);
            isActive = true;
        }
        #endif
    }
}