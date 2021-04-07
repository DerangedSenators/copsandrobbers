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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DerangedSenators.CopsAndRobbers.Control.Mobile
{
    /// <summary>
    ///     Base class for Mobile UI Buttons. This class should be expanded for additional implementations for other buttons
    /// </summary>
    /// @author Hanzalah Ravat
    public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        /// <summary>
        ///     Default Image Sprite. Used when the button is depressed
        /// </summary>
        public Image ButtonSprite;

        /// <summary>
        ///     The Default Sprite
        /// </summary>
        public Sprite DefaultSprite;

        /// <summary>
        ///     Optional Param for if you want to have a toggleable button
        /// </summary>
        public Sprite ToggleSprite;

        /// <summary>
        ///     Required if you want to toggle the sprites
        /// </summary>
        public bool allowToggling;

        /// <summary>
        ///     Change image when button is released
        /// </summary>
        public bool toggleOnRelease;

        private List<IButtonListener> _buttonListeners;
        private bool isPressed;

        private bool isToggle;

        private void Awake()
        {
            _buttonListeners = new List<IButtonListener>();
        }

        /// <summary>
        ///     Event that is triggered when the poly is clicked.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            foreach (var buttonListener in _buttonListeners) buttonListener.onButtonPressed();

            if (allowToggling)
            {
                if (!toggleOnRelease)
                {
                    if (isToggle)
                    {
                        ButtonSprite.sprite = DefaultSprite;
                        isToggle = false;
                    }
                    else
                    {
                        ButtonSprite.sprite = ToggleSprite;
                        isToggle = true;
                    }
                }
                else
                {
                    ButtonSprite.sprite = ToggleSprite;
                }
            }
        }

        /// <summary>
        ///     Event to be triggered when the poly is released
        /// </summary>
        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;

            foreach (var buttonListener in _buttonListeners) buttonListener.onButtonReleased();

            if (allowToggling && toggleOnRelease) ButtonSprite.sprite = DefaultSprite;
        }

        public void AddListener(IButtonListener listener)
        {
            _buttonListeners.Add(listener);
        }
    }
}