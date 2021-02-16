using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] Text moneyText;
        private static long moneyCount;
        private int copsMoney;
        private int robbersMoney;
        //public NetworkIdentity myNID;

        /// <summary>
        /// treasury is 0 when starting the game.
        /// </summary>
        void Start()
        {
            //gameObject.SetActive(true);
            moneyCount = 0;
            copsMoney = 0;
            robbersMoney = 0;
            moneyText.text = "$" + moneyCount.ToString();
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        //[Command] 
        public void CMDCollectMoney(int teamID)
        {
            if (teamID == 1) 
            {
                copsMoney += 100;
            }
            else
            {
                robbersMoney += 100;
            }
            moneyCount += 100;
            Debug.Log("copsMoney: " + copsMoney + ", robbersMoney: " + robbersMoney + ", Overall: " + moneyCount);
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
            moneyText.text = "$" + moneyCount.ToString();
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