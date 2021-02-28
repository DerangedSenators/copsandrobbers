using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using Me.DerangedSenators.CopsAndRobbers;
using UnityEngine.UI;

/// <summary>
/// Base class for Mobile UI Buttons. This class should be expanded for additional implementations for other buttons
/// </summary>
/// @author Hanzalah Ravat
public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    private List<IButtonListener> _buttonListeners;

    /// <summary>
    /// Default Image Sprite. Used when the button is depressed
    /// </summary>
    public Image ButtonSprite;

    private bool isPressed;
    private void Awake()
    {
        _buttonListeners = new List<IButtonListener>();
    }

    public void AddListener(IButtonListener listener)
    {
        _buttonListeners.Add(listener);
    }

    /// <summary>
    /// Event that is triggered when the poly is clicked.
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

        foreach (var buttonListener in _buttonListeners)
        {
            buttonListener.onButtonPressed();
        }
    }

    /// <summary>
    /// Event to be triggered when the poly is released
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;

        foreach (var buttonListener in _buttonListeners)
        {
            buttonListener.onButtonReleased();
        }
    }
}
