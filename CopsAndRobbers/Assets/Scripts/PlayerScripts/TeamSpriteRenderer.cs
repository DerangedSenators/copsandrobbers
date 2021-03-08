using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    /// Class used to set sprites depending on Team
    /// </summary>
    /// @author Hanzalah Ravat
    public class TeamSpriteRenderer: MonoBehaviour
    {
        /// <summary>
        /// The Player that is attached to this component
        /// </summary>
        public Player player;

        /// <summary>
        /// The SpriteRenderer assigned to this script
        /// </summary>
        public SpriteRenderer sprite;

        /// <summary>
        /// The Sprite used by the Cops
        /// </summary>
        public Sprite CopSprite;
        /// <summary>
        /// The Sprite used by Robbers
        /// </summary>
        public Sprite RobberSprite;

        private void OnEnable()
        {
            // Check this player's team
            Debug.Log($"This Player is {player.teamId}");
            if (player.teamId == 1)
            {
                SetSprite(Teams.COPS);
            }
            else
            {
                SetSprite(Teams.ROBBERS);
                
            }
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