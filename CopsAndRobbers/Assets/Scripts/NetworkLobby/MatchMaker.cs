using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Me.DerangedSenators.CopsAndRobbers
{
    [System.Serializable]
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

        public Match() { }
    }

    [System.Serializable]
    public class SyncListGameObject : SyncList<GameObject> { }

    [System.Serializable]
    public class SyncListMatch : SyncList<Match> { }

    public class MatchMaker : NetworkBehaviour
    {
        public static MatchMaker instance;
        public SyncListMatch matches = new SyncListMatch();
        public SyncList<string> matchIds = new SyncList<string>();

        [SerializeField] private GameObject turnManagerPrefab;

        void Start()
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
                Match match = new Match(matchId, host);
                match.publicMatch = publicMatch;
                matches.Add(match);
                //*Debug.Log($"Match generated");
                playerIndex = 1;
                teamId = 1;
                return true;
            }
            else
            {
                //*Debug.Log($"Match ID already exists");
                return false;
            }

        }
        
        public bool JoinGame(string matchId, GameObject player, out int playerIndex, out int teamId)
        {
            playerIndex = -1;
            teamId = -1;
            if (matchIds.Contains(matchId))
            {
                for(int i = 0; i < matches.Count; i++)
                {
                    if (matches[i].matchId == matchId)
                    {
                        matches[i].players.Add(player);
                        playerIndex = matches[i].players.Count;
                        if(playerIndex % 2 == 0)
                        {
                            teamId = 2;
                        }
                        else
                        {
                            teamId = 1;
                        }
                        break;
                    }
                }
                //*Debug.Log($"Match joined");
                return true;
            }
            else
            {
                //*Debug.Log($"Match ID does not exist");
                return false;
            }
        }

        public bool SearchGame(GameObject player, out int playerIndex, out string matchId, out int teamId)
        {
            playerIndex = -1;
            teamId = -1;
            matchId = string.Empty;
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].publicMatch && !matches[i].inMatch && !matches[i].matchFull)
                {
                    matchId = matches[i].matchId;
                    if (JoinGame(matchId, player, out playerIndex, out teamId))
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }

        public void BeginGame(string matchId)
        {
            GameObject newTurnManager = Instantiate(turnManagerPrefab);
            NetworkServer.Spawn(newTurnManager); //spawn turn manager on all clients
            newTurnManager.GetComponent<NetworkMatchChecker>().matchId =  matchId.ToGuid();
            TurnManager turnManager = newTurnManager.GetComponent<TurnManager>();

            for (int i = 0; i < matches.Count; i++)
            {
                if(matches[i].matchId == matchId)
                {
                    foreach (var player in matches[i].players)
                    {
                        Player _player = player.GetComponent<Player>();
                        turnManager.AddPlayer(_player);
                        _player.StartGame();
                    }
                    break;
                }
            }

        }

        public static string GetRandomMatchId()
        {
            string id = string.Empty;

            for(int i = 0; i < 6; i++)
            {
                int random = UnityEngine.Random.Range(0, 36);
                if(random < 26)
                {
                    id += (char)(random + 65); //get capital letter
                }
                else
                {
                    id += (random - 26).ToString();
                }
            }
            //*Debug.Log($"Random match ID: {id}");

            return id;
        }
        public void PlayerDisconnected(Player player, string matchId)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if(matches[i].matchId == matchId)
                {
                    int playerIndex = matches[i].players.IndexOf(player.gameObject);
                    matches[i].players.RemoveAt(playerIndex);
                    //*Debug.Log($"Player disconnected from match: {matchId} | Remaining players: {matches[i].players.Count}");

                    if(matches[i].players.Count == 0)
                    {
                        //*Debug.Log($"No more players in match. Terminating {matchId}");
                        matches.RemoveAt(i);
                        matchIds.Remove(matchId);
                    }
                    break;
                }
            }
        }

    }

    

    public static class MatchExtensions
    {
        public static Guid ToGuid(this string id)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.Default.GetBytes(id);
            byte[] hashBytes = provider.ComputeHash(inputBytes);

            return new Guid(hashBytes);
        }
    }
}