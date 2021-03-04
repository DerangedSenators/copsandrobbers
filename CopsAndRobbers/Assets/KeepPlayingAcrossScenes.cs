using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayingAcrossScenes : MonoBehaviour
{
    public AudioSource music;
    public bool playing;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length <= 1 && playing == true) { music.Play(); } // only plays if there is no music playing already
        else if (playing == true) { Destroy(GameObject.FindGameObjectsWithTag("Music")[1]); }            // removes any overlapping audio
        else { Destroy(GameObject.FindWithTag("Music")); }                                               // removes music object
        DontDestroyOnLoad(transform.gameObject);

    }

}

