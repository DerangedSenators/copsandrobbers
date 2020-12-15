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
        [SerializeField] private Button joinButton;
        [SerializeField] private Button hostButton;
        [SerializeField] private Canvas lobbyCanvas;

        [Header("Lobby")]
        [SerializeField] private Transform UIPlayerParent;
        [SerializeField] private GameObject UIPlayerPrefab;

        [SerializeField] private Text matchIdText;
        [SerializeField] private GameObject beginButton;

        void Start()
        {
            instance = this;
        }

        public void Host()
        {
            joinMatchInput.interactable = false;
            joinButton.interactable = false;
            hostButton.interactable = false;

            Player.localPlayer.HostGame();
        }

        public void HostSuccess(bool success)
        {
            if (success)
            {
                lobbyCanvas.enabled = true;

                SpawnUIPlayerPrefab(Player.localPlayer);

                matchIdText.text = Player.localPlayer.MatchId;
                beginButton.SetActive(true);
            }
            else
            {
                joinMatchInput.interactable = true;
                joinButton.interactable = true;
                hostButton.interactable = true;
            }
        }

        public void Join()
        {
            joinMatchInput.interactable = false;
            joinButton.interactable = false;
            hostButton.interactable = false;

            Player.localPlayer.JoinGame(joinMatchInput.text.ToUpper());
        }

        public void JoinSuccess(bool success, string matchId)
        {
            if (success) 
            {
                lobbyCanvas.enabled = true;

                SpawnUIPlayerPrefab(Player.localPlayer);

                matchIdText.text = matchId;
            }
            else
            {
                joinMatchInput.interactable = true;
                joinButton.interactable = true;
                hostButton.interactable = true;
            }
        }

        public void SpawnUIPlayerPrefab(Player player)
        {
            GameObject newUIPlayer = Instantiate(UIPlayerPrefab, UIPlayerParent);
            newUIPlayer.GetComponent<UIPlayer>().SetPlayer(player);
        }

        public void BeginGame()
        {
            Player.localPlayer.BeginGame();
        }
    }
}