///<summary>Toggles fullscreen mode for non-mobile displays</summary>
///@author Elliot Willis

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    public void Toggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
