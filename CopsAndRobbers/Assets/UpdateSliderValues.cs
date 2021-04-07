using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    ///<summary>Updates music/sfx sliders to correct value when they are loaded</summary>
    ///@author Elliot Willis and Nisath Mohamed Nasar
    public class UpdateSliderValues : MonoBehaviour
    {
        public Slider sfxSlider, musicSlider;

        public AudioSource sfx, music;

        public GameObject sfxGO;

        private void Awake()
        {
            //sfx = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
            //music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            sfxGO = GameObject.FindWithTag("SFX");
            sfx = sfxGO.GetComponent<AudioSource>();
            music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();

            //AudioSource[] audioSources = sfx.GetComponents<AudioSource>();
            var audioSources = sfxGO.GetComponents<AudioSource>();

            foreach (var audiosource in audioSources) audiosource.volume = sfxSlider.value;

            //sfx.GetComponent<AudioSource>().volume = sfxSlider.value;

            music.GetComponent<AudioSource>().volume = musicSlider.value;
        }
    }
}