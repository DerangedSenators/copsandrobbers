using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class TimeManager : MonoBehaviour
    {
        private float currentTime = 0f;
        
        private float startingTime = 10f;
        private float round2Time = 20f;
        
        [SerializeField] private GameObject moneyManagerGO;

        [SerializeField] Text countdownText;

        [SerializeField]
        private RoundManager _roundManager;
        
        void Start()
        {
            currentTime = startingTime;
        }

        void Update()
        {
            currentTime -= 1 * Time.deltaTime;
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

            countdownText.text = minutes + ":" + seconds;
            
            if (currentTime <= 0)
            {
                //currentTime = startingTime;
                currentTime = round2Time;
                
                _roundManager.LoadRound();

                if (_roundManager.GetCurrentRound() == RoundManager.Round.ENDED)
                {
                    DontDestroyOnLoad(moneyManagerGO);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
                }
                
            }
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