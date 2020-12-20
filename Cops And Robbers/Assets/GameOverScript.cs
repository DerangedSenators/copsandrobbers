using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class GameOverScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void NextRound()
        {
            //loads up next scene in the queue
            SceneManager.LoadScene(0);
        }

    }
}