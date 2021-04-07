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

namespace DerangedSenators.CopsAndRobbers.Control.Mobile
{
    /// <summary>
    ///     This interface must be implemented by any class to subscribe to button actions on the mobile canvas
    /// </summary>
    /// @author Hanzalah Ravat
    public interface IButtonListener
    {
        /// <summary>
        ///     Event to be triggered when the button is pressed
        /// </summary>
        void onButtonPressed();

        /// <summary>
        ///     Event to be triggered when the button is released
        /// </summary>
        void onButtonReleased();
    }
}