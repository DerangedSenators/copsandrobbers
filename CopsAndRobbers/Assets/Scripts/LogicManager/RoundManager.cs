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

using System;
using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers;
using UnityEngine;
using UnityEngine.UI;


namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed Nasar, Piotr Krawiec and Hanzalah Ravat
    /// <summary>
    /// Detect round and move player to set map locations
    /// </summary>
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private Text currentRoundTextUI;
        private Rigidbody2D localPlayerRB;
        private int localIndex = -1;
        public enum Round
        {
            FREEZE,
            ROUND1, 
            ROUND2, 
            ROUND3, 
            ENDED
        }

        private Round _currentRound;

        void Start()
        {
            _currentRound = Round.FREEZE;
            UpdateRoundTextView(1);
        }

        private void Update()
        {
            if (localPlayerRB == null)
            {
                Debug.Log("localPlayerRB is null, trying to Player.localPlayer.GetComponent<Rigidbody2D>();");
                localPlayerRB = Player.localPlayer.GetComponent<Rigidbody2D>();
            }

            if (localIndex != -1)
            {
                localIndex = Player.localPlayer.playerIndex;
                //TransformPlayersRound1();
            }
        }

        /// <summary>
        /// This method, checks current round and loads next round accordingly.
        /// </summary>
        public void LoadRound()
        {
            switch (_currentRound)
            {
                case Round.FREEZE :
                    _currentRound = Round.ROUND1;
                    TransformPlayersRound1();
                    break;
                case Round.ROUND1 :
                    TransformPlayersRound2();
                    _currentRound = Round.ROUND2;
                    break;
                case Round.ROUND2 :
                    _currentRound = Round.ROUND3;
                    TransformPlayersRound3();
                    break;
                case Round.ROUND3 :
                    _currentRound = Round.ENDED;
                    break;
            }
            
        }


        public void LoadFreezeRound()
        {
            //disable player components
            
        }
        
        //!!!!!!!!!!!Refactor this to one code 
        
        public void TransformPlayersRound1()
        {
            if (Player.localPlayer.teamId == 1)
            {
                //localPlayerRB.MovePosition(new Vector2(49.63f+localIndex,-52));
                localPlayerRB.position = new Vector2(47f+localIndex,52);
            }
            else if(Player.localPlayer.teamId == 2)
            {
                //localPlayerRB.MovePosition(new Vector2(-29.4f+localIndex,-45.18f));
                //localPlayerRB.position = new Vector2(-22.36f+localIndex,-56);
                localPlayerRB.position = new Vector2(1f+localIndex,-56);
            }
            UpdateRoundTextView(1);
        }
        
        public void TransformPlayersRound2()
        {
            if (Player.localPlayer.teamId == 1)
            {
               // localPlayerRB.MovePosition(new Vector2(186-localIndex,-103));
                //localPlayerRB.position = new Vector2(186 - localIndex, -103);
                //localPlayerRB.position = new Vector2(224.16f - localIndex, -62.4f);
                localPlayerRB.position = new Vector2(241-localIndex,-62);
            }
            else if (Player.localPlayer.teamId == 2)
            {
                //localPlayerRB.MovePosition(new Vector2(108+localIndex,-17));
                //localPlayerRB.position = new Vector2(108 + localIndex, -17);
                //localPlayerRB.position = new Vector2(113.7f + localIndex, -18);
                localPlayerRB.position = new Vector2(90+localIndex,-31);
            }
            UpdateRoundTextView(2);
        }
        
        public void TransformPlayersRound3()
        {
            if (Player.localPlayer.teamId == 1)
            {
                //localPlayerRB.MovePosition(new Vector2(-105+localIndex,-6.6f));
                //localPlayerRB.position = new Vector2(-105 + localIndex, -6.6f);
                localPlayerRB.position = new Vector2(-105+localIndex,-6.6f);
            }
            else if(Player.localPlayer.teamId == 2)
            {
                //localPlayerRB.MovePosition(new Vector2(-172 + localIndex, -29));
                //localPlayerRB.position = new Vector2(-172 + localIndex, -29);
                localPlayerRB.position = new Vector2(-172 + localIndex, -29);
            }
            UpdateRoundTextView(3);
        }

        /// <summary>
        /// returns current round
        /// </summary>
        /// <returns></returns>
        public Round GetCurrentRound()
        {
            return _currentRound;
        }

        /// <summary>
        /// sets current round.
        /// </summary>
        /// <param name="targetRound"></param>
        public void SetRound(Round targetRound)
        {
            _currentRound = targetRound;
        }

        /// <summary>
        /// displays round text
        /// </summary>
        /// <param name="roundNumber"></param>
        private void UpdateRoundTextView(int roundNumber)
        {
            currentRoundTextUI.text = $"Round {roundNumber}/3";
        }


    }
}