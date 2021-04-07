/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

///<summary> Sets the resolution of the application window on non-mobile displays</summary>
///@author Elliot Willis

using UnityEngine;

public class SetResolution : MonoBehaviour
{
    public void ScreenSize(int y)
    {
        var x = 1280; //default size
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