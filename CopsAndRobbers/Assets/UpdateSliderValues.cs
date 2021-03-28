///<summary>Updates music/sfx sliders to correct value when they are loaded</summary>
///@author Elliot Willis

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Me.DerangedSenators.CopsAndRobbers
{

    public class UpdateSliderValues : MonoBehaviour
    {
        public Slider sfxSlider, musicSlider;

        public AudioSource sfx, music;

        void Awake()
        {
            //sfx = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
            //music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
            
            
        }

        void FixedUpdate()
        {
            //sfx = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
            //music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();

            AudioSource[] audioSources = sfx.GetComponents<AudioSource>();

            foreach (var audiosource in audioSources)
            {
                audiosource.volume = sfxSlider.value;
            }
            
            //sfx.GetComponent<AudioSource>().volume = sfxSlider.value;
            
            music.GetComponent<AudioSource>().volume = musicSlider.value;
        }
    }

}