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

using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed Nasar, Piotr Krawiec and Hanzalah Ravat
    /// <summary>
    /// This script manages interacts with UI and Round Manager to control the time behaviours
    /// </summary>
    public class TimeManager : NetworkBehaviour
    {
        [SerializeField] private float currentTime = 0f;
        private float startingTime = 10f;

        /// <summary>
        /// The length of each round
        /// </summary>
        public float RoundTime;

        /// <summary>
        /// Duration of pre-game freeze
        /// </summary>
        public float FreezeTime;

        /// <summary>
        /// Duration of each break
        /// </summary>
        public float BreakTime;

        /// <summary>
        /// The total number of rounds
        /// </summary>
        public const int NumberOfRounds = 3;

        [SerializeField] private GameObject moneyManagerGO;

        [SerializeField] Text CountdownText;

        [SerializeField] private RoundManager _roundManager;

        [SerializeField] private Text _endOfRoundText;
        [SerializeField] private Text _breakTimerText;
        [SerializeField] private GameObject _breakCanvas;
        [SerializeField] private GameObject _freezeCanvas;
        [SerializeField] private Text _freezeTimer;
        [SerializeField] private GameObject _mainTimerCanvas;

        private Dictionary<int, bool> _roundInf;


        private int _currentRound;
        private bool _freezeActive;
        private bool _breakActive;
        private int _activeRound; // Dict index for active round
        private static bool _isRefreshSpawn;
        private PlayerMovement _localPlayerMovement;

        void Start()
        {
            // Init rounds
            _roundInf = new Dictionary<int, bool>();
            for (int i = 1; i <= NumberOfRounds; i++)
            {
                Debug.Log($"I value is {i}");
                _roundInf.Add(i, false);
            }

            _breakCanvas.gameObject.SetActive(false);
            _freezeCanvas.gameObject.SetActive(false);
            _isRefreshSpawn = false;
            // Activate a freeze
            currentTime = FreezeTime;
            _freezeActive = true;
            _currentRound = 1;
        }

        private void FixedUpdate()
        {
            if (_localPlayerMovement == null)
                _localPlayerMovement = Player.localPlayer.GetComponent<PlayerMovement>();
        }

        void Update()
        {
            StandardizeTime();
            if (_freezeActive && _currentRound == 1)
            {
                _localPlayerMovement.enabled = false;
                _freezeCanvas.SetActive(true);
                _mainTimerCanvas.SetActive(false);
                _roundManager.TransformPlayersAndUpdateViews(_currentRound);
            }
            else if (_breakActive)
                _breakTimerText.text = CountdownText.text;

            if (_freezeActive)
                _freezeTimer.text = CountdownText.text;

            if (currentTime <= 0)
            {
                if (_roundManager.GetCurrentRound() == RoundManager.Round.ENDED)
                {
                    DontDestroyOnLoad(moneyManagerGO);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if (_freezeActive) // End Of Freeze
                {
                    Debug.Log($"End Of Freeze");
                    _freezeActive = false;
                    Debug.Log($"Next Round is {_currentRound}");
                    _roundInf[_currentRound] = true;
                    currentTime = RoundTime;
                    _localPlayerMovement.enabled = true;
                    _freezeCanvas.SetActive(false);
                    _mainTimerCanvas.SetActive(true);
                }
                else if (_roundInf[_currentRound])
                {
                    _roundInf[_currentRound] = false;
                    _localPlayerMovement.enabled = false;
                    _endOfRoundText.text = $"End of Round {_currentRound}";
                    if (_currentRound != NumberOfRounds)
                    {
                        _isRefreshSpawn = true;
                        _breakActive = true;
                        currentTime = BreakTime;
                        _breakCanvas.SetActive(true);
                    }

                    switch (_currentRound)
                    {
                        case 1:
                        case 2:
                            _roundManager.TransformPlayersAndUpdateViews(_currentRound+1);
                            break;
                        case 3:
                            DontDestroyOnLoad(moneyManagerGO);
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            break;
                    }
                    _currentRound++;
                }
                else if (_breakActive)
                {
                    _breakActive = false;
                    _freezeActive = true;
                    currentTime = FreezeTime;
                    Debug.Log("Counting down freeze time");
                    _localPlayerMovement.enabled = false;
                    //_roundManager.LoadRound();
                    _breakCanvas.SetActive(false);
                    _freezeCanvas.SetActive(true);
                    _mainTimerCanvas.SetActive(false);
                }

            }
        }


        // Decrements and displays time.  
        private void StandardizeTime()
        {
            currentTime -= 1 * Time.deltaTime;
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

            CountdownText.text = minutes + ":" + seconds;

            if (NetworkServer.active)
            {
                Debug.Log("I AM THE SERVER DUDE");
            }
        }

        /// <summary>
        /// Call this method to force-end the timer + move to next scene. 
        /// </summary>
        public void EndTimer()
        {
            currentTime = startingTime;
        }

        public static bool ShouldRefreshRespawn()
        {
            return _isRefreshSpawn;
        }

        public static void SetIsRefreshSpawn(bool state)
        {
            _isRefreshSpawn = state;
        }

        public bool HasATeamDied()
        {

            return false;
        }

        public static void ForceEndRound()
        {
            //force end round
        }
    }
}