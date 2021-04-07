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
    public class UIPlayer : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Image copImage;
        [SerializeField] private Image robberImage;

        private Player player;

        public void SetPlayer(Player player)
        {
            this.player = player;
            text.text = "Player " + player.playerIndex;
            if (player.teamId == 1)
            {
                copImage.enabled = true;
                robberImage.enabled = false;
            }
            else
            {
                copImage.enabled = false;
                robberImage.enabled = true;
            }
        }
    }
}