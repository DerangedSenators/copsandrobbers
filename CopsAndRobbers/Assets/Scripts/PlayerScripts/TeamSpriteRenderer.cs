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

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    ///     Class used to set sprites depending on Team
    /// </summary>
    /// @author Hanzalah Ravat
    public class TeamSpriteRenderer : MonoBehaviour
    {
        /// <summary>
        ///     The Player that is attached to this component
        /// </summary>
        public Player player;

        /// <summary>
        ///     The SpriteRenderer assigned to this script
        /// </summary>
        public SpriteRenderer sprite;

        /// <summary>
        ///     The Sprite used by the Cops
        /// </summary>
        public Sprite CopSprite;

        /// <summary>
        ///     The Sprite used by Robbers
        /// </summary>
        public Sprite RobberSprite;

        private void OnEnable()
        {
            // Check this player's team
            if (player.teamId == 1)
                SetSprite(Teams.COPS);
            else
                SetSprite(Teams.ROBBERS);
        }

        private void SetSprite(Teams team)
        {
            switch (team)
            {
                case Teams.COPS:
                    sprite.sprite = CopSprite;
                    break;
                case Teams.ROBBERS:
                    sprite.sprite = RobberSprite;
                    break;
            }
        }
    }
}