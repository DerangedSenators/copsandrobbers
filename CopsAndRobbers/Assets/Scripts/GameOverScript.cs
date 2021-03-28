using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    
    /// @authors Nisath Mohamed
    public class GameOverScript : MonoBehaviour
    {
        private int[] moneyCounts;
        
        [SerializeField] private Text myTeamCountText;
        [SerializeField] private Text enemyTeamCountText;
        [SerializeField] public Text winText;
        [SerializeField] public Text loseText;
        [SerializeField] public Text drawText;
        [SerializeField] public NetworkManager networkManager;
        
        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            networkManager = NetworkManager.singleton;
        }

        void Update()
        {
            //Ensures this method is only executed only once.
            if (moneyCounts != null)
            {
                return;
            }
            
            RefreshTextViews();
            
        }

        /// <summary>
        /// Check what team this client belongs to, then set field texts to win, draw or lose appropriately.
        /// Also check display their money counts appropriately.
        /// </summary>
        private void RefreshTextViews()
        {
            //get array of moneycount where position 0 belongs to cops and 1 to robbers.
            moneyCounts = MoneyManager.GetMoneyCounts();
            
            switch (Player.localPlayer.teamId) //get teamid
            {
                case 1: //if client is cops
                    myTeamCountText.text = $"${moneyCounts[0].ToString()}";
                    enemyTeamCountText.text = $"${moneyCounts[1].ToString()}";
                    if (moneyCounts[0] > moneyCounts[1]) //if cops win
                    {
                        ActivateTextView(true, false, false); //display win message
                    } 
                    else if (moneyCounts[0] == moneyCounts[1]) // if match draw
                    {
                        ActivateTextView(false, true, false); //display draw message
                    }
                    else //if cops lose
                    {
                        ActivateTextView(false, false, true); //display lose message
                    }
                    break;
                case 2: //if client is robbers
                    myTeamCountText.text = $"${moneyCounts[1].ToString()}";
                    enemyTeamCountText.text = $"${moneyCounts[0].ToString()}";
                    if (moneyCounts[1] > moneyCounts[0]) // if robbers win
                    {
                        ActivateTextView(true, false, false); //display win message
                    }
                    else if (moneyCounts[0] == moneyCounts[1]) // if match draw
                    {
                        ActivateTextView(false, true, false); //display draw message
                    }
                    else //if cops win
                    {
                        ActivateTextView(false, false, true); //display lose message
                    }
                    break;
                default:
                    myTeamCountText.text = "$0";
                    break;
            }
        }

        /// <summary>
        /// Show one of the three messages once the game has ended.
        /// </summary>
        /// <param name="won">Notifies player for winning.</param>
        /// <param name="draw">Notifies player for a draw.</param>
        /// <param name="lost">Notifies player for losing.</param>
        private void ActivateTextView(bool won, bool draw, bool lost)
        {
            winText.gameObject.GetComponent<Text>().enabled = won;
            drawText.gameObject.GetComponent<Text>().enabled = draw;
            loseText.gameObject.GetComponent<Text>().enabled = lost;
        }
        
        /// <summary>
        /// Stops game and moves onto main menu.
        /// </summary>
        public void NextRound()
        {
            networkManager.StopClient();
            SceneManager.LoadScene(0);
            Destroy(GameObject.Find("MoneyManager"));
        }
    }
}