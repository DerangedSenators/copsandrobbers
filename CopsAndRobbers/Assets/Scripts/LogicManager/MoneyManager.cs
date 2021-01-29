using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyManager : NetworkBehaviour
    {
        [SerializeField] Text moneyText;
        private static long moneyCount;

        /// <summary>
        /// treasury is 0 when starting the game.
        /// </summary>
        void Start()
        {
            //gameObject.SetActive(true);
            moneyCount = 0;
            moneyText.text = "$" + moneyCount.ToString();
        }

        /// <summary>
        /// Adds $100 to treasury. 
        /// </summary>
        public void CollectMoney()
        {
            moneyCount += 100;
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