using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class UILobby : MonoBehaviour
    {

        public static UILobby instance;
        [Header("Host/Join")]
        [SerializeField] private InputField joinMatchInput;

        [SerializeField] private List<Selectable> lobbySelectables = new List<Selectable>();
        [SerializeField] private Canvas lobbyCanvas;
        [SerializeField] private Canvas searchCanvas;

        [Header("Lobby")]
        [SerializeField] private Transform UIPlayerParent;
        [SerializeField] private GameObject UIPlayerPrefab;

        [SerializeField] private Text matchIdText;
        [SerializeField] private GameObject beginButton;

        bool searching = false;

        GameObject playerLobbyUI;

        void Start()
        {
            instance = this;
        }

        public void HostPrivate()
        {
            joinMatchInput.interactable = false;

            lobbySelectables.ForEach(x => x.interactable = false);

            Player.localPlayer.HostGame(false);
        }


        public void HostPublic()
        {
            joinMatchInput.interactable = false;

            lobbySelectables.ForEach(x => x.interactable = false);

            Player.localPlayer.HostGame(true);
        }

        public void HostSuccess(bool success, string matchId)
        {
            if (success)
            {
                lobbyCanvas.enabled = true;

                if (playerLobbyUI != null) Destroy(playerLobbyUI);
                playerLobbyUI = SpawnUIPlayerPrefab(Player.localPlayer);

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

            Player.localPlayer.JoinGame(joinMatchInput.text.ToUpper());
        }

        public void JoinSuccess(bool success, string matchId)
        {
            if (success) 
            {
                lobbyCanvas.enabled = true;
                beginButton.SetActive(false);

                if (playerLobbyUI != null) Destroy(playerLobbyUI);
                playerLobbyUI = SpawnUIPlayerPrefab(Player.localPlayer);

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
            GameObject newUIPlayer = Instantiate(UIPlayerPrefab, UIPlayerParent);
            newUIPlayer.GetComponent<UIPlayer>().SetPlayer(player);
            newUIPlayer.transform.SetSiblingIndex(player.playerIndex - 1);

            return newUIPlayer;
        }


        public void BeginGame()
        {
            Player.localPlayer.BeginGame();
        }

        public void SearchGame()
        {
            Debug.Log($"Searching for game");
            searchCanvas.enabled = true;
            StartCoroutine(SearchingForGame());
        }

        IEnumerator SearchingForGame()
        {
            searching = true;
            WaitForSeconds checkeEveryNSeconds = new WaitForSeconds(1);
            while (searching)
            {
                yield return checkeEveryNSeconds;
                if (searching)
                {
                    Player.localPlayer.SearchGame();
                }
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
            Player.localPlayer.DisconnectGame();

            lobbyCanvas.enabled = false;
            lobbySelectables.ForEach(x => x.interactable = true);
            beginButton.SetActive(false);
        }
    }
}