using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This Class is designed to manage money between each team and also tracks the overall amount of money collected
    /// </summary>
    /// <author> Hanzalah Ravat </author>
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    /// <author> Naim Ahmed </author>
    public class MoneyManager : MonoBehaviour
    {
        //[SerializeField] Text moneyText;
        public static readonly int IncrementValue = 100;
        private static long moneyCount;
        private static TeamMoneyCount copsMoneyCount;
        private static TeamMoneyCount robberMoneyCount;
        public static TeamMoneyCount CopsMoneyCount => copsMoneyCount;
        public static TeamMoneyCount RobberMoneyCount => robberMoneyCount;


        /// <summary>
        /// Struct to hold team and money value
        /// </summary>
        public struct TeamMoneyCount
        {
            private Teams team;
            public int money;

            public TeamMoneyCount(Teams team)
            {
                this.team = team;
                money = 0;
            }
        } 

        private void Awake()
        {
            //*Debug.Log("Money Manager is Awake!");
            copsMoneyCount = new TeamMoneyCount(Teams.COPS);
            robberMoneyCount = new TeamMoneyCount(Teams.ROBBERS);
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        //[Command]
        public void CMDCollectMoney(int teamID)
        {
            //*Debug.Log($"CMDCollectMoney has been invoked by {teamID}");
            Teams updateTeam = (Teams) teamID;
            //*Debug.Log($"{updateTeam.ToString()} I'm {teamID} attempting to CMDCollectMoney");
            switch (updateTeam)
            {
                case Teams.ROBBERS:
                    copsMoneyCount.money += IncrementValue;
                    Debug.Log($"Increased Robbers Money {copsMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateCopsView(copsMoneyCount.money);
                    break;
                case Teams.COPS:
                    
                    robberMoneyCount.money += IncrementValue;
                    Debug.Log($"Increased Cops Money {robberMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateRobbersView(robberMoneyCount.money);
                    break;
            }
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