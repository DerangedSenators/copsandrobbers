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

namespace DerangedSenators.CopsAndRobbers.Sounds
{
    /// @authors Elliot Willis and Nisath Mohamed Nasar
    /// <summary>
    ///     Prevents music from being stopped during scene change, and allows the scene to decide whether to play/stop music
    /// </summary>
    public class KeepPlayingAcrossScenes : MonoBehaviour
    {
        public AudioSource music;
        public bool playing;

        private void Awake()
        {
            if (GameObject.FindGameObjectsWithTag("Music").Length <= 1 && playing)
            {
                music.Play();
            } // only plays if there is no music playing already
            else if (playing)
            {
                //Destroy(GameObject.FindGameObjectsWithTag("Music")[1]);
            } // removes any overlapping audio

            DontDestroyOnLoad(GameObject.FindWithTag("Music"));
            DontDestroyOnLoad(GameObject.FindWithTag("SFX"));
        }
    }
}