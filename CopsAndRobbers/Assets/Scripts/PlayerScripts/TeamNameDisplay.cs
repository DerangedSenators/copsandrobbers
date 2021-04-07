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
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Elliot Willis
    /// <summary>
    ///     Displays the name of the player's team at the start of the round
    /// </summary>
    public class TeamNameDisplay : MonoBehaviour
    {
        public GameObject roundStartTextField;
        public Text text;
        private bool done;
        private int ID = -1;
        private float timeUp = 5f;


        private void Update()
        {
            if (ID == -1)
            {
                ID = Player.localPlayer.teamId;
            }
            else
            {
                AssignString();
                timeUp -= Time.deltaTime;
                if (timeUp <= 0f) roundStartTextField.SetActive(false);
            }
        }

        private void AssignString()
        {
            if (!done)
            {
                //text = roundStartTextField.GetComponent<Text>();
                switch (ID)
                {
                    case 1:
                        text.text = text.text + " COPS \n DEFEND THE MONEY!";
                        break;
                    case 2:
                        text.text = text.text + " ROBBERS \n STEAL THE MONEY";
                        break;
                }

                roundStartTextField.SetActive(true);
                done = true;
            }
        }
    }
}