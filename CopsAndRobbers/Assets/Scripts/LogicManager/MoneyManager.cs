using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyManager : MonoBehaviour
    {
        //[SerializeField] Text moneyText;
        private static long moneyCount;
        private int copsMoney;
        private int robbersMoney;
        private int teamID = 0; //cops = 1, robbers = 2
        //public NetworkIdentity myNID;
        private RobbersMoneyUpdater _robbersMoneyUpdater;
        private CopsMoneyUpdater _copsMoneyUpdater;
        
        private bool firstOneDone = false;

        /// <summary>
        /// treasury is 0 when starting the game.
        /// </summary>
        void Start()
        {
            //gameObject.SetActive(true);
            //moneyCount = 0;
            //copsMoney = 0;
            //robbersMoney = 0;
            //moneyText.text = "$" + moneyCount.ToString();
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        //[Command] 
        public void CMDCollectMoney(int teamID)
        {
            this.teamID = teamID;
            if (!firstOneDone)
            {
                if (teamID == 1)
                {
                    //copsMoney += 100;
                    //moneyText.text = "$" + copsMoney.ToString();
                    //_copsMoneyUpdater = new CopsMoneyUpdater();
                    gameObject.AddComponent<CopsMoneyUpdater>();
                    _copsMoneyUpdater = GetComponent<CopsMoneyUpdater>();
                }
                else if (teamID == 2)
                {
                    //robbersMoney += 100;
                    //money.text = "$" + robbersMoney.ToString();
                    gameObject.AddComponent<RobbersMoneyUpdater>();
                    _robbersMoneyUpdater = GetComponent<RobbersMoneyUpdater>();
                }

                firstOneDone = true;
            }

            if (teamID == 1)
            {
                _copsMoneyUpdater.AddMoney(100);
            }
            else if (teamID == 2)
            {
                _robbersMoneyUpdater.AddMoney(100);
            }
            //moneyCount += 100;
        }

        /// <summary>
        /// Get amount of money in treasury.
        /// </summary>
        /// <returns>amount of amount in treasury</returns>
        public long getMoneyCount()
        {
            return moneyCount;
        }

        private void Update()
        {
            //moneyText.text = "$" + moneyCount.ToString();

            if(teamID == 1)
            {
                //moneyText.text = "$" + copsMoney.ToString();
                //Debug.Log("Displaying cops money");
            }
            
            else if(teamID == 2)
            {
               // moneyText.text = "$" + robbersMoney.ToString();
                //Debug.Log("Displaying robbers money");
            }
        }

        /*
        void Awake()
        {
            gameObject.SetActive(true);
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (this != null)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        */
    }
}