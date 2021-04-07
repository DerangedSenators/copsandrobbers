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

using System.Collections;
using System.Collections.Generic;
using DerangedSenators.CopsAndRobbers.GameObjects.Player;
using UnityEngine;
using UnityEngine.UI;

namespace DerangedSenators.CopsAndRobbers.Screens.Lobby
{
    public class UILobby : MonoBehaviour
    {
        public static UILobby instance;

        [Header("Host/Join")] [SerializeField] private InputField joinMatchInput;

        [SerializeField] private List<Selectable> lobbySelectables = new List<Selectable>();
        [SerializeField] private Canvas lobbyCanvas;
        [SerializeField] private Canvas searchCanvas;

        [Header("Lobby")] [SerializeField] private Transform UIPlayerParent;

        [SerializeField] private GameObject UIPlayerPrefab;

        [SerializeField] private Text matchIdText;
        [SerializeField] private GameObject beginButton;

        private GameObject playerLobbyUI;

        private bool searching;

        private void Start()
        {
            instance = this;
        }

        public void HostPrivate()
        {
            joinMatchInput.interactable = false;

            lobbySelectables.ForEach(x => x.interactable = false);

            Player.LocalPlayer.HostGame(false);
        }


        public void HostPublic()
        {
            joinMatchInput.interactable = false;

            lobbySelectables.ForEach(x => x.interactable = false);
            Debug.Log($"Player is: {Player.LocalPlayer}");
            Player.LocalPlayer.HostGame(true);
            //*Debug.Log($"Player hosting a public game");
        }

        public void HostSuccess(bool success, string matchId)
        {
            if (success)
            {
                lobbyCanvas.enabled = true;

                if (playerLobbyUI != null) Destroy(playerLobbyUI);
                playerLobbyUI = SpawnUIPlayerPrefab(Player.LocalPlayer);

                matchIdText.text = matchId;
                beginButton.SetActive(true);
            }
            else
            {
                joinMatchInput.interactable = true;


                lobbySelectables.ForEach(x => x.interactable = true);
            }
        }

        public void Join()
        {
            joinMatchInput.interactable = false;

            lobbySelectables.ForEach(x => x.interactable = false);

            Player.LocalPlayer.JoinGame(joinMatchInput.text.ToUpper());
        }

        public void JoinSuccess(bool success, string matchId)
        {
            if (success)
            {
                lobbyCanvas.enabled = true;
                beginButton.SetActive(false);

                if (playerLobbyUI != null) Destroy(playerLobbyUI);
                playerLobbyUI = SpawnUIPlayerPrefab(Player.LocalPlayer);

                matchIdText.text = matchId;
            }
            else
            {
                joinMatchInput.interactable = true;


                lobbySelectables.ForEach(x => x.interactable = true);
            }
        }

        public GameObject SpawnUIPlayerPrefab(Player player)
        {
            var newUIPlayer = Instantiate(UIPlayerPrefab, UIPlayerParent);
            newUIPlayer.GetComponent<UIPlayer>().SetPlayer(player);
            newUIPlayer.transform.SetSiblingIndex(player.playerIndex - 1);

            return newUIPlayer;
        }


        public void BeginGame()
        {
            Player.LocalPlayer.BeginGame();
            lobbyCanvas.enabled = false;
        }

        public void SearchGame()
        {
            //*Debug.Log($"Searching for game");
            searchCanvas.enabled = true;
            StartCoroutine(SearchingForGame());
        }

        private IEnumerator SearchingForGame()
        {
            searching = true;
            var checkeEveryNSeconds = new WaitForSeconds(1);
            while (searching)
            {
                yield return checkeEveryNSeconds;
                if (searching) Player.LocalPlayer.SearchGame();
            }
        }

        public void SearchSuccess(bool success, string matchId)
        {
            if (success)
            {
                searchCanvas.enabled = false;
                JoinSuccess(success, matchId);
                searching = false;
            }
        }

        public void SearchCancel()
        {
            searchCanvas.enabled = false;
            searching = false;

            lobbySelectables.ForEach(x => x.interactable = true);
        }

        public void DisconnectLobby()
        {
            if (playerLobbyUI != null) Destroy(playerLobbyUI);
            Player.LocalPlayer.DisconnectGame();

            lobbyCanvas.enabled = false;
            lobbySelectables.ForEach(x => x.interactable = true);
            beginButton.SetActive(false);
        }
    }
}