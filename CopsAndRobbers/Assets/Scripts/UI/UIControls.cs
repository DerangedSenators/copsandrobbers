using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed
    public class UIControls : MonoBehaviour
    {
        [SerializeField] private Canvas menuCanvas;
        private bool viewMenu;

        public class PauseMenuButtonHandler : IButtonListener
        {
            private UIControls _menu;

            public PauseMenuButtonHandler(UIControls menu)
            {
                this._menu = menu;
            }
            public void onButtonPressed()
            {
                if (!_menu.viewMenu)
                {

                    _menu.viewMenu = true;

                }
                else
                {
                    _menu.viewMenu = false;
                }
            }

            public void onButtonReleased()
            {
                // Do Nothing here
            }
        }

        private void Start()
        {
            if (ControlContext.Instance.Active)
            {
                ControlContext.Instance.OptionsButton.AddListener(new PauseMenuButtonHandler(this));
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (viewMenu)
            {
                menuCanvas.gameObject.SetActive(true);
            }
            else
            {
                menuCanvas.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !menuCanvas.gameObject.activeSelf)
            {
                viewMenu = true;
                return;
            }


            if (Input.GetKeyDown(KeyCode.Escape) && menuCanvas.gameObject.activeSelf)
            {
                viewMenu = false;
                return;
            }

        }

        /// <summary>
        /// Programatically set the visibility of the menu
        /// </summary>
        /// <param name="visibility"></param>
        public void SetMenuVisibility(bool visibility)
        {
            viewMenu = visibility;
        }
        
    }
}