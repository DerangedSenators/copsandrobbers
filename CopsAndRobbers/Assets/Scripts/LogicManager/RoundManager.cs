﻿using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers;
using UnityEngine;
using UnityEngine.UI;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private Text currentRoundTextUI;
        
        public enum Round
        {
            ROUND1, ROUND2, ROUND3, ENDED
        }

        private Round _currentRound;

        void Start()
        {
            _currentRound = Round.ROUND1;
            UpdateRoundTextView(1);
        }
        
        public void LoadRound()
        {
            switch (_currentRound)
            {
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

        //!!!!!!!!!!!Refactor this to one code 
        public void TransformPlayersRound2()
        {
            if (Player.localPlayer.teamId == 1)
            {
                Vector3 newPos = new Vector3(186 - Player.localPlayer.playerIndex, -103, -101);
                Player.localPlayer.transform.position = newPos;
            }
            else
            {
                Vector3 newPos = new Vector3(108 + Player.localPlayer.playerIndex, -17, -101);
                Player.localPlayer.transform.position = newPos;
            }
            UpdateRoundTextView(2);
        }
        
        public void TransformPlayersRound3()
        {
            if (Player.localPlayer.teamId == 1)
            {
                Vector3 newPos = new Vector3(-105 + Player.localPlayer.playerIndex, -6.6f, -30);
                Player.localPlayer.transform.position = newPos;
            }
            else
            {
                Vector3 newPos = new Vector3(-172 + Player.localPlayer.playerIndex, -29, -30);
                Player.localPlayer.transform.position = newPos;
            }
            UpdateRoundTextView(3);
        }

        public Round GetCurrentRound()
        {
            return _currentRound;
        }

        public void SetRound(Round targetRound)
        {
            _currentRound = targetRound;
        }

        public void UpdateRoundTextView(int roundNumber)
        {
            currentRoundTextUI.text = $"Round {roundNumber}/3";
        }


        void FixedUpdate()
        {
            
        }
    }
}