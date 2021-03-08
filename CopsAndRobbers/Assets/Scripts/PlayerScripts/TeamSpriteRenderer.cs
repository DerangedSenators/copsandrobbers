using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers.Weapons
{
    /// <summary>
    /// Class used to set sprites depending on Team
    /// </summary>
    /// @author Hanzalah Ravat
    public class TeamSpriteRenderer: NetworkBehaviour
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

        [SyncVar (hook = "OnChangeTeam")]
        public string SpriteName;
        private void OnEnable()
        {
            // Check this player's team
            Debug.Log($"This Player is {player.teamId}");
            if (player.teamId == 1)
            {
                SpriteName = CopSprite.name;
                Debug.Log($"Sprite Name is {SpriteName}");
            }
            else
            {
                SpriteName = RobberSprite.name;
                Debug.Log($"Sprite Name is {SpriteName}");            }
        }

        void OnChangeTeam(string oldSpriteName, string spriteName)
        {
            Debug.Log("Sprite Changer Invoked!.");
            sprite.sprite = Resources.Load<Sprite>(spriteName) as Sprite;
        }
        
        [Client]
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