using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Script for handling Coin Pickup Events
    /// </summary>
    public class CoinPickup : MonoBehaviour
    {
        /// <summary>
        /// Variable responsable for the text 
        /// </summary>
        [SerializeField]
        private Text coinText;
    
        private bool isPickUpAllowed;

        private MoneyManager moneyManager;

        //public Money money;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
            //At the start of the game the text will be turned off
            coinText.gameObject.SetActive(false);
            moneyManager = FindObjectOfType<MoneyManager>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        private void Update()
        {
            //checking if user is allowed to pick up the coin && if the user pressed "E"
            if (isPickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        /// <summary>
        /// When collider is triggered we are checking if it was a Player1 Object - If it is we make the text appear as well as making the coin pickable
        /// </summary>
        /// <param name="collision">The collision component of the object that is colliding with this object?</param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name.Equals("Cop"))
            {
                coinText.gameObject.SetActive(true);
                isPickUpAllowed = true;
            }
        }

        /// <summary>
        /// In this function we are doing the reverse of the pervious one
        /// </summary>
        /// <param name="collision">The collision component of the object that is colliding with this object?</param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name.Equals("Cop"))
            {
                coinText.gameObject.SetActive(false);
                isPickUpAllowed = false;
            }
        }

        /// <summary>
        /// This fucntion removes the object when it is picked up
        /// </summary>
        private void PickUp()
        {
            moneyManager.CollectMoney();
            Destroy(gameObject);
        }
    }

}
