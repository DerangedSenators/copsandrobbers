using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*@author Peter
*/

//This script is responible for the fucntion of the healthbar
public class HealthBar : MonoBehaviour
{

    //This variable allows us to use a slider from the unity UI
    public Slider slider;

    //this variable will allow us to suer gradient depending on the current hp
    public Gradient gradient;

    public Image fill;


    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        // making the color to most right place on a gradient in this case it is green
       fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        //Because of how slider work we need to pass it using a normalizedValue becasue gradient goes form 0 to 1 while our health can go form 0 to 100
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}

