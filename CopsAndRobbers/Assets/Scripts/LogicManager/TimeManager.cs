using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    // <@authors Nisath Mohamed Nasar and Piotr Krawiec
    /// <summary>
    /// This script manages interacts with UI and Round Manager to control the time behaviours
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        private float currentTime = 0f;
        
        private float startingTime = 10f;

        [SerializeField] private GameObject moneyManagerGO;

        [SerializeField] Text countdownText;

        [SerializeField]
        private RoundManager _roundManager;

        [SerializeField] private Text endOfRoundText;
        [SerializeField] private Text breakTimerText;
        [SerializeField] private GameObject breakCanvas;
        [SerializeField] private GameObject freezeCanvas;
        [SerializeField] private Text freezeTimer;
        [SerializeField] private GameObject mainTimerCanvas;
        
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

         private static bool isRefreshSpawn;
        
        void Start()
        {
            freezeTime = 10f;
            currentTime = freezeTime;
            freeze1 = true;
            round1Time = 60*3f;
            round2Time = 60*3f;
            round3Time = 60*3f;
            breakTime = 60f;
            breakCanvas.gameObject.SetActive(false);
            freezeCanvas.gameObject.SetActive(false);

            isRefreshSpawn = false;
        }

        void Update()
        {
            StandardizeTime();

            //disable movement in the beginning
            if (freeze1)
            {
                Player.localPlayer.GetComponent<PlayerMovement>().enabled = false;  //disable movement
                freezeCanvas.gameObject.SetActive(true);
                mainTimerCanvas.gameObject.SetActive(false);
            }

            if (breakRound1 || breakRound2)
            {
                breakTimerText.text = countdownText.text;
            }

            if (freeze1 || freeze2 || freeze3)
            {
                freezeTimer.text = countdownText.text;
            }
            
            
            if (currentTime <= 0) //timers ended
            {
                //currentTime = startingTime;
                //currentTime = round2Time;

                //This if statement disables freeze1 and starts round1, sets timer to round1timer and loads round1.
                if (freeze1) //round 1
                {
                    freeze1 = false;
                    round1 = true;
                    currentTime = round1Time;
                    Debug.Log("current counting round1 time");
                    
                    _roundManager.LoadRound();

                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = true;   //enable movement
                    
                    freezeCanvas.gameObject.SetActive(false);
                    mainTimerCanvas.gameObject.SetActive(true);
                }
                //This if statement disables round1, enables break1 and sets timer to break time.
                else if (round1) //break
                {
                    round1 = false;
                    breakRound1 = true;
                    currentTime = breakTime;
                    Debug.Log("current counting breakround1 time");
                    
                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = false; //disable movement
                    
                    breakCanvas.gameObject.SetActive(true);
                    endOfRoundText.text = $"End of round 1";
                    
                    isRefreshSpawn = true;

                }
                //This if statement disables break, enables freeze2 and sets timer to freeze time.
                else if (breakRound1) //freeze2
                {
                    breakRound1 = false;
                    freeze2 = true;
                    currentTime = freezeTime;
                    Debug.Log("current counting freeze2 time");
                    
                    _roundManager.LoadRound();
                    
                    breakCanvas.gameObject.SetActive(false);
                    freezeCanvas.gameObject.SetActive(true);
                    mainTimerCanvas.gameObject.SetActive(false);
                    
                }

                else if (freeze2) //round2
                {
                    freeze2 = false;
                    round2 = true;
                    currentTime = round2Time;
                    
                    Debug.Log("current counting round2 time");
                    
                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = true;   //enable movement
                    
                    freezeCanvas.gameObject.SetActive(false);
                    mainTimerCanvas.gameObject.SetActive(true);
                }

                else if (round2)//break
                {
                    round2 = false;
                    breakRound2 = true;
                    currentTime = round3Time;
                    
                    Debug.Log("current counting breakround2 time");
                    
                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = false;  //disable movement
                    
                    breakCanvas.gameObject.SetActive(true);
                    endOfRoundText.text = $"End of round 2";
                    
                    isRefreshSpawn = true;
                }

                else if (breakRound2)//freeze3
                {
                    breakRound2 = false;
                    freeze3 = true;
                    currentTime = freezeTime;
                    
                    Debug.Log("current counting freeze3 time");
                    
                    _roundManager.LoadRound();
                    
                    breakCanvas.gameObject.SetActive(false);
                    
                    freezeCanvas.gameObject.SetActive(true);
                    mainTimerCanvas.gameObject.SetActive(false);
                    
                }

                else if (freeze3) //round3
                {
                    freeze3 = false;
                    round3 = true;
                    currentTime = round3Time;
                    
                    Debug.Log("current counting round3 time");
                    
                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = true;   //enable movement
                    
                    freezeCanvas.gameObject.SetActive(false);
                    mainTimerCanvas.gameObject.SetActive(true);
                }

                else if (round3) //ending
                {
                    round3 = false;
                    Player.localPlayer.GetComponent<PlayerMovement>().enabled = false;   //disable movement
                    _roundManager.LoadRound();
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

        public static bool ShouldRefreshRespawn()
        {
            return isRefreshSpawn;
        }

        public static void SetIsRefreshSpawn(bool state)
        {
            isRefreshSpawn = state;
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