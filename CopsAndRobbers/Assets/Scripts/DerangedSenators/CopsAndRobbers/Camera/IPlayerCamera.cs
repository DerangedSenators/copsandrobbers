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

using UnityEngine;

namespace DerangedSenators.CopsAndRobbers.Camera
{
    /// <summary>
    ///     This interface must be implemented by any and all classes that want to provide an additonal perspective for the
    ///     player in the form of a Camera.
    /// </summary>
    /// @author Hanzalah Ravat
    public interface IPlayerCamera
    {
        /// <summary>
        ///     Assigns the camera with a transform to follow
        /// </summary>
        /// <param name="transform">The transform that the camera must follow</param>
        void assignFollowTransform(Transform transform);

        /// <summary>
        ///     Checks if a Transform is already assigned to the player
        /// </summary>
        /// <returns> True if the camera has a transform assigned otherwise false.</returns>
        bool isAssigned();
    }
}