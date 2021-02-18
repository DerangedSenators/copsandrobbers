using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Script to control MoneyUI Element
    /// </summary>
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] Text moneyText;

        private static MoneyDisplay _instance;

        public static MoneyDisplay Instance() => _instance;

        public void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.Log($"Destroying instance");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log($"Setting instance");
                _instance = this;
            }
        }
        
        public void UpdateView(int moneyCount)
        {
            moneyText.text = "$" + moneyCount.ToString();
        }
    }
} 