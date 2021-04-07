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

using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    ///     Script to control MoneyUI Element
    /// </summary>
    /// <author> Hanzalah Ravat </author>
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    /// <author> Naim Ahmed </author>
    public class MoneyDisplay : MonoBehaviour
    {
        private static MoneyDisplay _instance;
        [SerializeField] private Text copsMoneyText;
        [SerializeField] private Text robbersMoneyText;

        public void Awake()
        {
            if (_instance != null && _instance != this)
                //*Debug.Log($"Destroying instance");
                Destroy(gameObject);
            else
                //*Debug.Log($"Setting instance");
                _instance = this;
        }

        public static MoneyDisplay Instance()
        {
            return _instance;
        }

        public void UpdateView(int moneyCount)
        {
            copsMoneyText.text = "$" + moneyCount;
        }

        public void UpdateCopsView(int moneyCount)
        {
            copsMoneyText.text = "$" + moneyCount;
        }

        public void UpdateRobbersView(int moneyCount)
        {
            robbersMoneyText.text = "$" + moneyCount;
        }
    }
}