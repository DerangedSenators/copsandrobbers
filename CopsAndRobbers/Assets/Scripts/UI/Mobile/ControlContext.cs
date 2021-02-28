using System;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This is a Singleton Class that can be used by other classes (Prefab Scripts) to access Mobile UI objects. It also dictates whether or not they are displayed on the screen
    /// </summary>
    /// @author Hanzalah Ravat
    public class ControlContext: MonoBehaviour
    {
        public Joystick MovementStick;
        public Joystick AttackCircleStick;
        public GameObject ControlCanvas;
        public MobileButton AttackButton;
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
        }

        private void Start()
        {
            isEnabled();
        }


#if UNITY_STANDALONE || UNITY_WEBPLAYER
        private void isEnabled()
        {
            if(ControlCanvas != null)
                ControlCanvas.SetActive(false);
            isActive = false;
        }
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        private void isEnabled()
        {
            if(ControlCanvas != null)
                ControlCanvas.SetActive(true);
            isActive = true;
            Debug.Log("Game is in Mobile Mode");
        }
        #endif
    }
}