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

using System;
using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class BulletHandler: NetworkBehaviour
    {
        public Rigidbody2D BulletRigidbody;

        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.name.Equals("Player(Clone)"))
            {
                collider.gameObject.GetComponent<BulletDetector>().CmdDepleteHealth();
            }
            Player.localPlayer.CmdDestroyBullet(BulletRigidbody.gameObject);
        }

    }
}