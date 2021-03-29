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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MainMenu : MonoBehaviour
    {

        void Start()
        {
            if (Application.isBatchMode) //Headless Build for Server 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

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