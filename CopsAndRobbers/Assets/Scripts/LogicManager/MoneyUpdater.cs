using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Class used by player types to trigger MoneyDisplayUI to update
    /// </summary>
    /// <author> Hanzalah Ravat </author>
    public class MoneyUpdater : NetworkBehaviour
    {
        public Teams mTeam;
        
        /*
        private void Update()
        {
            try
            {
                // Try and check if it is cop or robber without TeamID as it might be unreliable
                // Trying to work using inverse of enemy layer
                // //*Debug.Log($"This is a Local Player. Updating MoneyCount on UI. My Team is {mTeam}");
                // Update the moneyDisplay
                int money = 0;
                switch (mTeam)
                {
                    case Teams.COPS:
                        // //*Debug.Log("This is a cop... Updating Cop Money");
                        money = MoneyManager.CopsMoneyCount.money;
                        break;
                    case Teams.ROBBERS:
                        // //*Debug.Log("This is a Robber... Updating Robber Money");
                        money = MoneyManager.RobberMoneyCount.money;
                        break;
                }

                MoneyDisplay.Instance().UpdateView(money);
            }
            catch (NullReferenceException exception)
            {
                // Do NOTHING;
            }
        }*/
    }
}