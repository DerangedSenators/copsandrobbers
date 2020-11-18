using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyManager : MonoBehaviour
    {
        private static long moneyCount;

        /// <summary>
        /// treasury is 0 when starting the game.
        /// </summary>
        void Start()
        {
            moneyCount = 0;
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        public void CollectMoney()
        {
            moneyCount += 100;
        }

        /// <summary>
        /// Get amount of money in treasury.
        /// </summary>
        /// <returns>amount of amount in treasury</returns>
        public long getMoneyCount()
        {
            return moneyCount;
        }
    }
}