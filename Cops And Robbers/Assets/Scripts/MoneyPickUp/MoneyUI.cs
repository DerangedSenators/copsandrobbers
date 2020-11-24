using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyUI : MonoBehaviour
    {
        //public MoneyManager moneyManager;
        public Text moneyText;

        /// <summary>
        /// Update text UI as the money count increases.
        /// </summary>
        private void FixedUpdate()
        {
            //moneyText.text = "$" + moneyManager.getMoneyCount().ToString("0");
        }
    }
}