using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Start the game
        /// </summary>
        public void PlayGame()
        {
            //loads up next scene in the queue
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        /// <summary>
        /// Quit the application
        /// </summary>
        public void QuitGame()
        {
            //quits the game, closes all processes
            Application.Quit();
        }
    }
}