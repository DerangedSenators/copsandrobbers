using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
/*
 * This script is responsible for picking up the coin and Informing the user to use "E" Key / 

@author Peter
*/
namespace Me.DerangedSenators.CopsAndRobbers
{
    public class CoinPickup : MonoBehaviour
    {
        //Variable responsable for the text 
        [SerializeField]
        private Text coinText;
    
        private bool isPickUpAllowed;
    
    
        // Start is called before the first frame update
       private  void Start()
        {
            //At the start of the game the text will be turned off
            coinText.gameObject.SetActive(false); 
        }
    
        // Update is called once per frame
        private void Update()
        {
            //checking if user is allowed to pick up the coin && if the user pressed "E"
            if (isPickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
    
        //When colider is Tiggered we are checking if it was a Player1 Object - If it is we make the text appear as well as making 
        //the coin pickable
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name.Equals("Player1"))
            {
                coinText.gameObject.SetActive(true);
                isPickUpAllowed = true;
            }
        }
    
        //In this function we are doing the reverse of the pervious one
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name.Equals("Player1"))
            {
                coinText.gameObject.SetActive(false);
                isPickUpAllowed = false;
            }
        }
    
        //This fucntion removes the object when it is picked up
        private void PickUp()
        {
            Destroy(gameObject);
        }
    }

}
