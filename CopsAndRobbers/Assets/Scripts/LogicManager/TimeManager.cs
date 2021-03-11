using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <author> Nisath Mohamed Nasar </author>
    /// <author> Piotr Krawiec</author>
    public class TimeManager : MonoBehaviour
    {
        private float currentTime = 0f;
        
        private float startingTime = 10f;

        [SerializeField] private GameObject moneyManagerGO;

        [SerializeField] Text countdownText;

        [SerializeField]
        private RoundManager _roundManager;


        private bool freeze1;
        private bool freeze2;
        private bool freeze3;
        private bool breakRound1;
        private bool breakRound2;
        private bool round1;
        private bool round2;
        private bool round3;
        private float freezeTime;
        private float round1Time;
        private float round2Time;
        private float round3Time;
        private float breakTime;
        
        void Start()
        {
            freezeTime = 5f;
            currentTime = freezeTime;
            freeze1 = true;
            round1Time = 30f;
            round2Time = 30f;
            round3Time = 30f;
            breakTime = 20f;
        }

        void Update()
        {
            StandardizeTime();
            
            if (currentTime <= 0) //timers ended
            {
                //currentTime = startingTime;
                //currentTime = round2Time;

                //This if statement disables freeze1 and starts round1, sets timer to round1timer and loads round1.
                if (freeze1)
                {
                    freeze1 = false;
                    round1 = true;
                    currentTime = round1Time;
                    Debug.Log("current counting round1 time");
                    
                    _roundManager.LoadRound();
                }
                //This if statement disables round1, enables break1 and sets timer to break time.
                else if (round1)
                {
                    round1 = false;
                    breakRound1 = true;
                    currentTime = breakTime;
                    Debug.Log("current counting breakround1 time");
                }
                //This if statement disables break, enables freeze2 and sets timer to freeze time.
                else if (breakRound1)
                {
                    breakRound1 = false;
                    freeze2 = true;
                    currentTime = freezeTime;
                    Debug.Log("current counting freeze2 time");
                    
                    _roundManager.LoadRound();
                }

                else if (freeze2)
                {
                    freeze2 = false;
                    round2 = true;
                    currentTime = round2Time;
                    
                    Debug.Log("current counting round2 time");
                    
                    
                }

                else if (round2)
                {
                    round2 = false;
                    breakRound2 = true;
                    currentTime = round3Time;
                    
                    Debug.Log("current counting breakround2 time");
                }

                else if (breakRound2)
                {
                    breakRound2 = false;
                    freeze3 = true;
                    currentTime = freezeTime;
                    
                    Debug.Log("current counting freeze3 time");
                    
                    _roundManager.LoadRound();
                }

                else if (freeze3)
                {
                    freeze3 = false;
                    round3 = true;
                    currentTime = round3Time;
                    
                    Debug.Log("current counting round3 time");
                }

                else if (round3)
                {
                    round3 = false;
                }

                
                
                
                

                //if round state is ended, make Moneymanager singleton and load game over scene.
                if (_roundManager.GetCurrentRound() == RoundManager.Round.ENDED)
                {
                    DontDestroyOnLoad(moneyManagerGO);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
                }
                
            }
        }

        
        // Decrements and displays time.  
        private void StandardizeTime()
        {
            currentTime -= 1 * Time.deltaTime;
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

            countdownText.text = minutes + ":" + seconds;
        }
        
        /// <summary>
        /// Call this method to force-end the timer + move to next scene. 
        /// </summary>
        public void EndTimer()
        {
            currentTime = startingTime;
        }
    }
}