using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class RoundBreakTimeManager : MonoBehaviour
    {
        public Button continueButton;


        [SerializeField] private Text countdownText;
        private float currentTime;
        private readonly float startingTime = 30f;

        private void Start()
        {
            currentTime = startingTime;
            continueButton.enabled = false;
        }

        private void Update()
        {
            currentTime -= 1 * Time.deltaTime;
            var minutes = Mathf.Floor(currentTime / 60).ToString("00");
            var seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

            countdownText.text = minutes + ":" + seconds;
            if (currentTime <= 0)
                //load roundbreak scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                continueButton.enabled = true;
        }

        /// <summary>
        ///     Call this method to force-end the timer + move to next scene.
        /// </summary>
        public void EndTimer()
        {
            currentTime = startingTime;
        }
    }
}