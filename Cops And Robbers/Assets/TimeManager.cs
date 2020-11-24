using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 120f;

    [SerializeField] Text countdownText;

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
        if (currentTime <= 0) { 
            //load roundbreak scene
        }
    }
}
