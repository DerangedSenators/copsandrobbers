using System.Collections;
using System.Collections.Generic;
using Me.DerangedSenators.CopsAndRobbers;
using UnityEngine;
using UnityEngine.UI;


namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    public class RoundManager : MonoBehaviour
    {
        [SerializeField] private Text currentRoundTextUI;
        
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
        
        /// <summary>
        /// This method, checks current round and loads next round accordingly.
        /// </summary>
        public void LoadRound()
        {
            switch (_currentRound)
            {
                case Round.FREEZE :
                    _currentRound = Round.ROUND1;
                    break;
                case Round.ROUND1 :
                    TransformPlayersRound2();
                    _currentRound = Round.ROUND2;
                    PlayerHealth pHealth = Player.localPlayer.GetComponent<PlayerHealth>(); 
                    pHealth.setIsAlive(true);
                    //Player.localPlayer.GetComponent<PlayerRespawn>().setRespawn(true);
                    pHealth.RespawnForNewRound();
                    pHealth.CmdRespawnForNewRound();
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