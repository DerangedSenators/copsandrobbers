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
    /// <author> Hanzalah Ravat </author>
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    /// <author> Naim Ahmed </author>
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] Text copsMoneyText;
        [SerializeField] Text robbersMoneyText;
        
        
        private static MoneyDisplay _instance;

        public static MoneyDisplay Instance() => _instance;

        public void Awake()
        {
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
        
        public void UpdateView(int moneyCount)
        {
            copsMoneyText.text = "$" + moneyCount.ToString();
        }
        
        public void UpdateCopsView(int moneyCount)
        {
            copsMoneyText.text = "$" + moneyCount.ToString();
        }
        
        public void UpdateRobbersView(int moneyCount)
        {
            robbersMoneyText.text = "$" + moneyCount.ToString();
        }
    }
} 