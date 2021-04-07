using UnityEngine;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class EndOfRoundScript : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }


        public void NextRound()
        {
            //loads up next scene in the queue
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}