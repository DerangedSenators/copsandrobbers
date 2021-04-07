/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    ///     This Class is designed to manage money between each team and also tracks the overall amount of money collected
    /// </summary>
    /// @authors Hanzalah Ravat, Nisath Mohamed Nasar, Piotr Krawiec, Naim Ahmed, Hannah Elliman
    public class MoneyManager : MonoBehaviour
    {
        //[SerializeField] Text moneyText;
        public static readonly int IncrementValue = 100;
        private static long moneyCount;
        private static TeamMoneyCount robberMoneyCount;
        private static TeamMoneyCount copsMoneyCount;

        public GameObject sfxHandler;
        public AudioClip moneyBagClip;
        public AudioSource moneyAudioSource;
        private int myTeamID = -1;
        public static TeamMoneyCount CopsMoneyCount => copsMoneyCount;
        public static TeamMoneyCount RobberMoneyCount => robberMoneyCount;

        private void Awake()
        {
            //*Debug.Log("Money Manager is Awake!");
            robberMoneyCount = new TeamMoneyCount(Teams.COPS);
            copsMoneyCount = new TeamMoneyCount(Teams.ROBBERS);
        }

        private void FixedUpdate()
        {
            if (moneyAudioSource == null)
            {
                moneyAudioSource = sfxHandler.AddComponent<AudioSource>();
                moneyAudioSource.clip = moneyBagClip;
            }
        }

        /// <summary>
        ///     Adds $100 to treasury.
        /// </summary>
        //[Command]
        public void CMDCollectMoney(int teamID)
        {
            moneyAudioSource.PlayOneShot(moneyBagClip);


            myTeamID = teamID;
            //*Debug.Log($"CMDCollectMoney has been invoked by {teamID}");
            var updateTeam = (Teams) teamID;
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
        ///     Removes $100 from the treasury when a player is respawned
        /// </summary>
        /// <param name="teamID"></param>
        public void SubtractMoney(int teamID)
        {
            //*Debug.Log($"CMDCollectMoney has been invoked by {teamID}");
            var updateTeam = (Teams) teamID;
            //*Debug.Log($"{updateTeam.ToString()} I'm {teamID} attempting to CMDCollectMoney");
            switch (updateTeam)
            {
                case Teams.ROBBERS:
                    robberMoneyCount.money -= IncrementValue / 2;
                    Debug.Log($"Decreased Robbers Money {robberMoneyCount.money}");
                    MoneyDisplay.Instance().UpdateCopsView(robberMoneyCount.money);
                    break;
                case Teams.COPS:

                    copsMoneyCount.money -= IncrementValue / 2;
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

        /// <summary>
        ///     Struct to hold team and money value
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
    }
}