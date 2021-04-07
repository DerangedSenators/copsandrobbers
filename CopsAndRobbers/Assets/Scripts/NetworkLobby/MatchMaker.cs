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
using System.Security.Cryptography;
using System.Text;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Me.DerangedSenators.CopsAndRobbers
{
    [Serializable]
    public class Match
    {
        public string matchId;
        public SyncListGameObject players = new SyncListGameObject();

        public bool publicMatch;
        public bool inMatch;
        public bool matchFull;

        public Match(string matchId, GameObject host)
        {
            this.matchId = matchId;
            players.Add(host);
        }

        public Match()
        {
        }
    }

    [Serializable]
    public class SyncListGameObject : SyncList<GameObject>
    {
    }

    [Serializable]
    public class SyncListMatch : SyncList<Match>
    {
    }

    public class MatchMaker : NetworkBehaviour
    {
        public static MatchMaker instance;
        public SyncListMatch matches = new SyncListMatch();

        [SerializeField] private GameObject turnManagerPrefab;
        public SyncList<string> matchIds = new SyncList<string>();

        private void Start()
        {
            instance = this;
        }

        public bool HostGame(string matchId, GameObject host, bool publicMatch, out int playerIndex, out int teamId)
        {
            playerIndex = -1;
            teamId = -1;
            if (!matchIds.Contains(matchId))
            {
                matchIds.Add(matchId);
                var match = new Match(matchId, host);
                match.publicMatch = publicMatch;
                matches.Add(match);
                //*Debug.Log($"Match generated");
                playerIndex = 1;
                teamId = 1;
                return true;
            }

            //*Debug.Log($"Match ID already exists");
            return false;
        }

        public bool JoinGame(string matchId, GameObject player, out int playerIndex, out int teamId)
        {
            playerIndex = -1;
            teamId = -1;
            if (matchIds.Contains(matchId))
            {
                for (var i = 0; i < matches.Count; i++)
                    if (matches[i].matchId == matchId)
                    {
                        matches[i].players.Add(player);
                        playerIndex = matches[i].players.Count;
                        if (playerIndex % 2 == 0)
                            teamId = 2;
                        else
                            teamId = 1;
                        break;
                    }

                //*Debug.Log($"Match joined");
                return true;
            }

            //*Debug.Log($"Match ID does not exist");
            return false;
        }

        public bool SearchGame(GameObject player, out int playerIndex, out string matchId, out int teamId)
        {
            playerIndex = -1;
            teamId = -1;
            matchId = string.Empty;
            for (var i = 0; i < matches.Count; i++)
                if (matches[i].publicMatch && !matches[i].inMatch && !matches[i].matchFull)
                {
                    matchId = matches[i].matchId;
                    if (JoinGame(matchId, player, out playerIndex, out teamId)) return true;
                }

            return false;
        }

        public void BeginGame(string matchId)
        {
            var newTurnManager = Instantiate(turnManagerPrefab);
            NetworkServer.Spawn(newTurnManager); //spawn turn manager on all clients
            newTurnManager.GetComponent<NetworkMatchChecker>().matchId = matchId.ToGuid();
            var turnManager = newTurnManager.GetComponent<TurnManager>();

            for (var i = 0; i < matches.Count; i++)
                if (matches[i].matchId == matchId)
                {
                    foreach (var player in matches[i].players)
                    {
                        var _player = player.GetComponent<Player>();
                        turnManager.AddPlayer(_player);
                        _player.StartGame();
                    }

                    break;
                }
        }

        public static string GetRandomMatchId()
        {
            var id = string.Empty;

            for (var i = 0; i < 6; i++)
            {
                var random = Random.Range(0, 36);
                if (random < 26)
                    id += (char) (random + 65); //get capital letter
                else
                    id += (random - 26).ToString();
            }
            //*Debug.Log($"Random match ID: {id}");

            return id;
        }

        public void PlayerDisconnected(Player player, string matchId)
        {
            for (var i = 0; i < matches.Count; i++)
                if (matches[i].matchId == matchId)
                {
                    var playerIndex = matches[i].players.IndexOf(player.gameObject);
                    matches[i].players.RemoveAt(playerIndex);
                    //*Debug.Log($"Player disconnected from match: {matchId} | Remaining players: {matches[i].players.Count}");

                    if (matches[i].players.Count == 0)
                    {
                        //*Debug.Log($"No more players in match. Terminating {matchId}");
                        matches.RemoveAt(i);
                        matchIds.Remove(matchId);
                    }

                    break;
                }
        }
    }


    public static class MatchExtensions
    {
        public static Guid ToGuid(this string id)
        {
            var provider = new MD5CryptoServiceProvider();
            var inputBytes = Encoding.Default.GetBytes(id);
            var hashBytes = provider.ComputeHash(inputBytes);

            return new Guid(hashBytes);
        }
    }
}