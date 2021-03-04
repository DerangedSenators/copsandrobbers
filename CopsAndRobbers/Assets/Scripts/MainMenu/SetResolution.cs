using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    public void ScreenSize(int y)
    {
        int x = 1280; //default size
        switch (y)
        {
            case 480:
                x = 853; //480 whilst reserving 16:9 aspect ratio
                break;
            case 720:
                x = 1280;
                break;
            case 1080:
                x = 1920;
                break;
            case 1440:
                x = 2560;
                break;
            case 2160:
                x = 3840;
                break;
        }
        Screen.SetResolution(x, y, Screen.fullScreen);
    }
}
