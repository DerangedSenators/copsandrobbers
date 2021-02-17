using System;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class RobbersMoneyUpdater : MonoBehaviour
    {
        private MoneyDisplay _moneyDisplay;
        private int robbersMoney;
        private void Start()
        {
            _moneyDisplay = FindObjectOfType<MoneyManager>().GetComponent<MoneyDisplay>();
        }
        
        private void Update()
        {
            if (_moneyDisplay == null)
            {
                Debug.Log("moneydisplay is null.");
                _moneyDisplay = GetComponent<MoneyDisplay>();
            }
        }

        public void AddMoney(int moneyCount)
        {
            robbersMoney += moneyCount;
            _moneyDisplay.UpdateView(robbersMoney);
        }
        
    }
}