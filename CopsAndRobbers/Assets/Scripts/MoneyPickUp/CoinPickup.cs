/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

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