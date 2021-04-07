using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    ///     Script used to allow exiting of pause menu
    /// </summary>
    public class MenuExitController : MonoBehaviour, IButtonListener
    {
        public MobileButton button;
        public UIControls uIControls;

        public void Start()
        {
            Debug.Log("Assigning Button");
            button.AddListener(this);
        }

        public void onButtonPressed()
        {
            Debug.Log("Button Pressed");
            uIControls.SetMenuVisibility(false);
        }

        public void onButtonReleased()
        {
            //Do Nothing
        }
    }
}