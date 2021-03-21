using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    
    public class GameOverScript : MonoBehaviour
    {
        private int[] moneyCounts;
        
        [SerializeField] private Text myTeamCountText;
        [SerializeField] private Text enemyTeamCountText;
        [SerializeField] public Text winText;
        [SerializeField] public Text loseText;
        
        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        void Update()
        {
            if (moneyCounts != null)
            {
                return;
            }
            
            moneyCounts = MoneyManager.GetMoneyCounts();
            
            switch (Player.localPlayer.teamId)
            {
                case 1:
                    myTeamCountText.text = $"${moneyCounts[0].ToString()}";
                    enemyTeamCountText.text = $"${moneyCounts[1].ToString()}";
                    if (moneyCounts[0] >= moneyCounts[1])
                    {
                        winText.gameObject.GetComponent<Text>().enabled = true;
                        loseText.gameObject.GetComponent<Text>().enabled = false;
                    }
                    else
                    {
                        winText.gameObject.GetComponent<Text>().enabled = false;
                        loseText.gameObject.GetComponent<Text>().enabled = true;
                    }

                    break;
                case 2:
                    myTeamCountText.text = $"${moneyCounts[1].ToString()}";
                    enemyTeamCountText.text = $"${moneyCounts[0].ToString()}";
                    if (moneyCounts[1] >= moneyCounts[0])
                    {
                        winText.gameObject.GetComponent<Text>().enabled = true;
                        loseText.gameObject.GetComponent<Text>().enabled = false;
                    }
                    else
                    {
                        winText.gameObject.GetComponent<Text>().enabled = false;
                        loseText.gameObject.GetComponent<Text>().enabled = true;
                    }
                    break;
                default:
                    myTeamCountText.text = "$0";
                    break;
            }
            
        }
        
        
        public void NextRound()
        {
        
            SceneManager.LoadScene(2);
        }
    }
}