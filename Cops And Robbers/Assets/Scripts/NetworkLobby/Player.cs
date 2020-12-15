using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace Me.DerangedSenators.CopsAndRobbers {
    public class Player : NetworkBehaviour
    {

        public static Player localPlayer;
        [SyncVar] public string MatchId;
        [SyncVar] public int playerIndex;

        NetworkMatchChecker networkMatchChecker;


        void Start()
        {
            networkMatchChecker = GetComponent<NetworkMatchChecker>();

            if (isLocalPlayer)
            {
                localPlayer = this;
                
            } 
            else
            {
                UILobby.instance.SpawnUIPlayerPrefab(this);
            }
        }
        

        /*
         * HOST GAME
         */
        
        public void HostGame()
        {
            string matchId = MatchMaker.GetRandomMatchId();
            CmdHostGame(matchId);
        }
        
        

        [Command]
        void CmdHostGame(string matchId)
        {
            MatchId = matchId;
            if (MatchMaker.instance.HostGame(matchId, gameObject, out playerIndex))
            {
                Debug.Log($"Game hosted successfully");

                networkMatchChecker.matchId = matchId.ToGuid();
                TargetHostGame(true, matchId);
            }
            else
            {
                Debug.Log($"Game host failed");
                TargetHostGame(false, matchId);
            }
        }

        [TargetRpc]
        void TargetHostGame(bool success, string matchId)
        {
            Debug.Log($"Match ID: {MatchId} == {matchId}");
            UILobby.instance.HostSuccess(success);
        }

        /*
         * JOIN GAME
         */

        public void JoinGame(string matchId)
        {
            string matchID = matchId;
            CmdJoinGame(matchID);
        }
        [Command]
        void CmdJoinGame(string matchId)
        {
            MatchId = matchId;
            if (MatchMaker.instance.JoinGame(matchId, gameObject, out playerIndex))
            {
                Debug.Log($"Game Joined successfully");

                networkMatchChecker.matchId = matchId.ToGuid();
                TargetJoinGame(true, matchId);
            }
            else
            {
                Debug.Log($"Game Join failed");
                TargetJoinGame(false, matchId);
            }
        }

        [TargetRpc]
        void TargetJoinGame(bool success, string matchId)
        {
            Debug.Log($"Match ID: {MatchId} == {matchId}");
            UILobby.instance.JoinSuccess(success, matchId);
        }

        /*
         * BEGIN GAME
         */

        public void BeginGame()
        {
            CmdBeginGame();
        }
        [Command]
        void CmdBeginGame()
        {
            MatchMaker.instance.BeginGame(MatchId);
            Debug.Log($"Game Begining");
        }

        public void StartGame()
        {
            TargetBeginGame();
        }

        [TargetRpc]
        void TargetBeginGame()
        {
            Debug.Log($"Match ID: {MatchId} | Beginning");
            //Additively load game scene
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        }
        
    }
}