using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed Nasar
    /// <summary>
    /// Find appropriate Platform and display controls accordingly.
    /// </summary>
    public class FindControls : MonoBehaviour
    {
        public GameObject mobileControls, desktopControls;
        
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        private void EnableControls()
        {
            desktopControls.gameObject.SetActive(true);
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE 
        private void EnableControls()
        {
            mobileControls.gameObject.SetActive(true);
        }
#endif

        private void Awake()
        {
            mobileControls.gameObject.SetActive(false);
            desktopControls.gameObject.SetActive(false);
            EnableControls();
        }
    }
}