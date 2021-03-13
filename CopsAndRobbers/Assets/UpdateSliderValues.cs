///<summary>Updates music/sfx sliders to correct value when they are loaded</summary>
///@author Elliot Willis

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValues : MonoBehaviour
{
    public Slider sfxSlider, musicSlider;
    void Awake()
    {
        sfxSlider.value = GameObject.FindWithTag("SFX").GetComponent<AudioSource>().volume;
        musicSlider.value = GameObject.FindWithTag("Music").GetComponent<AudioSource>().volume;
    }
}

