using Mirror;
using System.Collections;
using System.Collections.Generic;
//using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Script for handling Coin Pickup Events
    /// </summary>
    /// <author> Hanzalah Ravat </author>
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    public class CoinPickup : MonoBehaviour
    {
        //public GameObject moneyManagerGameObject;
        public MoneyManager moneyManager;

        private GameObject collidedPlayerObject;
        

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
            //At the start of the game the text will be turned off
            //coinText.gameObject.SetActive(false);
            //moneyManager = FindObjectOfType<MoneyManager>().GetComponent<MoneyManager>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        private void Update()
        {
            if (moneyManager == null) 
            {
                moneyManager = FindObjectOfType<MoneyManager>().GetComponent<MoneyManager>();
                //moneyManager = GetComponent<MoneyManager>();
                //moneyManager = moneyManagerGameObject.GetComponent<MoneyManager>();
            }
        }

        /// <summary>
        /// When collider is triggered we are checking if it was a Player1 Object - If it is we make the text appear as well as making the coin pickable
        /// </summary>
        /// <param name="collision">The collision component of the object that is colliding with this object?</param>
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name.Equals("Player(Clone)") ) 
            {
                collision.gameObject.GetComponent<Player>().DestroyMoneyBag(gameObject);
                moneyManager.CMDCollectMoney(collision.gameObject.GetComponent<Player>().GetTeamId());
            }
        }
        
    }

}