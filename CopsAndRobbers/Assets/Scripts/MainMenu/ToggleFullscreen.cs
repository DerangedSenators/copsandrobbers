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
