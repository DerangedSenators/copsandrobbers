namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This interface must be implemented by any class to subscribe to button actions on the mobile canvas
    /// </summary>
    /// @author Hanzalah Ravat
    public interface IButtonListener
    {
        /// <summary>
        /// Event to be triggered when the button is pressed
        /// </summary>
        void onButtonPressed();

        /// <summary>
        /// Event to be triggered when the button is released
        /// </summary>
        void onButtonReleased();
    }
}