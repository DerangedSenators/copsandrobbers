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

namespace DerangedSenators.CopsAndRobbers.Sounds
{
    /// @authors Nisath Mohamed Nasar
    /// <summary>
    ///     Remove Duplicates of this objects
    /// </summary>
    public class RemoveOtherInstances : MonoBehaviour
    {
        private void Awake()
        {
            if (GameObject.FindGameObjectsWithTag("SFX").Length <= 1)
            {
            }
            else // if theres more than one object of this type, keep this and remove others
            {
                Destroy(GameObject.FindWithTag("SFX"));
            }
        }
    }
}