///<summary>Prevents music from being stopped during scene change, and allows the scene to decide whether to play/stop music</summary>
///@author Elliot Willis

using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Elliot Willis and Nisath Mohamed Nasar
    /// <summary>
    ///     Add SFX and Music to DontDestroyOnLoad
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