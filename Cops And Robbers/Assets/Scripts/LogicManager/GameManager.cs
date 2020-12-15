using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// Singleton Class that manages the Game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        void Awake()
        {
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (gameManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameManager = this;
                DontDestroyOnLoad(gameObject);
            }
        }

    }
}
