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
    /// @authors Hanzalah Ravat, Nisath Mohamed Nasar, Piotr Krawiec, Naim Ahmed, Hannah Elliman 
    public class MoneyManager : MonoBehaviour
    {
        //[SerializeField] Text moneyText;
        public static readonly int IncrementValue = 375;
        private static long moneyCount;
        private static TeamMoneyCount robberMoneyCount;
        private static TeamMoneyCount copsMoneyCount;
        public static TeamMoneyCount CopsMoneyCount => copsMoneyCount;
        public static TeamMoneyCount RobberMoneyCount => robberMoneyCount;
        private int myTeamID = -1;

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
            robberMoneyCount = new TeamMoneyCount(Teams.COPS);
            copsMoneyCount = new TeamMoneyCount(Teams.ROBBERS);
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        //[Command]
        public void CMDCollectMoney(int teamID)
        {
            myTeamID = teamID;
            //*Debug.Log($"CMDCollectMoney has been invoked by {teamID}");
            Teams updateTeam = (Teams) teamID;
            //*Debug.Log($"{updateTeam.ToString()} I'm {teamID} attempting to CMDCollectMoney");
            switch (updateTeam)
            {
                case Teams.ROBBERS:
                    robberMoneyCount.money += IncrementValue;
                    Debug.Log($"Increased Robbers Money {robberMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateCopsView(robberMoneyCount.money);
                    break;
                case Teams.COPS:
                    
                    copsMoneyCount.money += IncrementValue;
                    Debug.Log($"Increased Cops Money {copsMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateRobbersView(copsMoneyCount.money);
                    break;
            }
        }

        /// <summary>
        /// Removes $100 from the treasury when a player is respawned
        /// </summary>
        /// <param name="teamID"></param>
        public void SubtractMoney(int teamID)
        {
            //*Debug.Log($"CMDCollectMoney has been invoked by {teamID}");
            Teams updateTeam = (Teams) teamID;
            //*Debug.Log($"{updateTeam.ToString()} I'm {teamID} attempting to CMDCollectMoney");
            switch (updateTeam)
            {
                case Teams.ROBBERS:
                    robberMoneyCount.money -= IncrementValue/2;
                    Debug.Log($"Decreased Robbers Money {robberMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateCopsView(robberMoneyCount.money);
                    break;
                case Teams.COPS:
                    
                    copsMoneyCount.money -= IncrementValue/2;
                    Debug.Log($"Decreased Cops Money {copsMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateRobbersView(copsMoneyCount.money);
                    break;
            }
        }

        public static int[] GetMoneyCounts()
        {
            int[] arr = {copsMoneyCount.money, robberMoneyCount.money};
            return arr;
        }

        public int GetMyTeamID()
        {
            return myTeamID;
        }
    }
}