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

using Mirror;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed Nasar and Naim Ahmed
    internal class GameNetworkManager : MonoBehaviour
    {
        public GameObject moneyBagPrefab;

        private void Start()
        {
            CmdSpawnMoneyBags();
            //SceneManager.sceneLoaded += delegate { SpawnMoneyBags(); };
        }

        public void ClientConnect()
        {
            ClientScene.RegisterPrefab(moneyBagPrefab);
            NetworkClient.RegisterHandler<ConnectMessage>(OnClientConnect);
            NetworkClient.Connect("localhost");
        }

        private void OnClientConnect(NetworkConnection nc, ConnectMessage cm)
        {
            //*Debug.Log("Connected to server: " + nc);
        }

        public void ServerListen()
        {
            NetworkServer.RegisterHandler<ConnectMessage>(OnServerConnect);
            NetworkServer.RegisterHandler<ReadyMessage>(OnClientReady);

            // start listening, and allow up to 4 connections
            NetworkServer.Listen(4);
        }

        private void OnClientReady(NetworkConnection arg1, ReadyMessage arg2)
        {
            //*Debug.Log("Client is ready to start: " + arg1);
            NetworkServer.SetClientReady(arg1);
            CmdSpawnMoneyBags();
            //throw new NotImplementedException()
        }

        //[Command]
        private void CmdSpawnMoneyBags()
        {
            //Map 1
            var map1x1 = 11.59f;
            var map1y1 = -0.75f;
            var map1x2 = 17.37f;
            var map1y2 = -1.1f;
            var map1x3 = 4.12f;
            var map1y3 = -0.8f;
            var map1x4 = 14.44f;
            var map1y4 = 9.33f;
            var map1x5 = -1.33f;
            var map1y5 = 2.95f;
            var map1x6 = -4.8f;
            var map1y6 = 13f;
            var map1x7 = 31.6f;
            var map1y7 = 13.55f;
            var map1x8 = 30.93f;
            var map1y8 = 21.64f;
            var map1x9 = 4.55f;
            var map1y9 = 9.89f;
            var map1x10 = 36.06f;
            var map1y10 = 30.54f;
            var map1x11 = 18.73f;
            var map1y11 = 27.28f;
            var map1x12 = 25.37f;
            var map1y12 = 30.72f;
            var map1x13 = 19.33f;
            var map1y13 = 20.03f;
            var map1x14 = -28.66f;
            var map1y14 = -25.76f;
            var map1x15 = -8.57f;
            var map1y15 = -14.23f;
            var map1x16 = -18.06f;
            var map1y16 = 12.35f;
            var map1x17 = -22.47f;
            var map1y17 = 23.33f;
            var map1x18 = -13.51f;
            var map1y18 = 23.05f;
            var map1x19 = -24.78f;
            var map1y19 = 30.05f;
            var map1x20 = -5.42f;
            var map1y20 = 29.76f;
            var map1x21 = -5.24f;
            var map1y21 = 20.59f;
            var map1x22 = -18.16f;
            var map1y22 = -21.08f;
            var map1x23 = -8.37f;
            var map1y23 = -22.57f;
            var map1x24 = -28.76f;
            var map1y24 = -14.16f;


            //Map 1
            var mbg1 = Instantiate(moneyBagPrefab, new Vector3(map1x1, map1y1, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg1);

            var mbg2 = Instantiate(moneyBagPrefab, new Vector3(map1x2, map1y2, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg2);

            var mbg3 = Instantiate(moneyBagPrefab, new Vector3(map1x3, map1y3, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg3);

            var mbg4 = Instantiate(moneyBagPrefab, new Vector3(map1x4, map1y4, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg4);

            var mbg5 = Instantiate(moneyBagPrefab, new Vector3(map1x5, map1y5, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg5);

            var mbg6 = Instantiate(moneyBagPrefab, new Vector3(map1x6, map1y6, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg6);

            var mbg7 = Instantiate(moneyBagPrefab, new Vector3(map1x7, map1y7, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg7);

            var mbg8 = Instantiate(moneyBagPrefab, new Vector3(map1x8, map1y8, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg8);

            var mbg9 = Instantiate(moneyBagPrefab, new Vector3(map1x9, map1y9, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg9);

            var mbg10 = Instantiate(moneyBagPrefab, new Vector3(map1x10, map1y10, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg10);

            var mbg11 = Instantiate(moneyBagPrefab, new Vector3(map1x11, map1y11, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg11);

            var mbg12 = Instantiate(moneyBagPrefab, new Vector3(map1x12, map1y12, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg12);

            var mbg13 = Instantiate(moneyBagPrefab, new Vector3(map1x13, map1y13, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg13);

            var mbg14 = Instantiate(moneyBagPrefab, new Vector3(map1x14, map1y14, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg14);

            var mbg15 = Instantiate(moneyBagPrefab, new Vector3(map1x15, map1y15, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg15);

            var mbg16 = Instantiate(moneyBagPrefab, new Vector3(map1x16, map1y16, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg16);

            var mbg17 = Instantiate(moneyBagPrefab, new Vector3(map1x17, map1y17, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg17);

            var mbg18 = Instantiate(moneyBagPrefab, new Vector3(map1x18, map1y18, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg18);

            var mbg19 = Instantiate(moneyBagPrefab, new Vector3(map1x19, map1y19, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg19);

            var mbg20 = Instantiate(moneyBagPrefab, new Vector3(map1x20, map1y20, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg20);

            var mbg21 = Instantiate(moneyBagPrefab, new Vector3(map1x21, map1y21, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg21);

            var mbg22 = Instantiate(moneyBagPrefab, new Vector3(map1x22, map1y22, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg22);

            var mbg23 = Instantiate(moneyBagPrefab, new Vector3(map1x23, map1y23, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg23);

            var mbg24 = Instantiate(moneyBagPrefab, new Vector3(map1x24, map1y24, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg24);


            //Map 2
            var map2x1 = 140.44f;
            var map2y1 = -61.23f;
            var map2x2 = 147.67f;
            var map2y2 = -61.31f;
            var map2x3 = 140.44f;
            var map2y3 = -61.23f;
            var map2x4 = 140.41f;
            var map2y4 = -45.73f;
            var map2x5 = 150.79f;
            var map2y5 = -46.22f;
            var map2x6 = 162.26f;
            var map2y6 = -45.57f;
            var map2x7 = 152.73f;
            var map2y7 = -53.16f;
            var map2x8 = 161.86f;
            var map2y8 = -57.26f;
            var map2x9 = 155.89f;
            var map2y9 = -65.39f;
            var map2x10 = 171.24f;
            var map2y10 = -48.06f;
            var map2x11 = 175.03f;
            var map2y11 = -56.77f;
            var map2x12 = 182.37f;
            var map2y12 = -62.6f;
            var map2x13 = 175.58f;
            var map2y13 = -39.13f;
            var map2x14 = 162.68f;
            var map2y14 = -66.03f;
            var map2x15 = 170.17f;
            var map2y15 = -65.72f;
            var map2x16 = 140.97f;
            var map2y16 = -73.94f;
            var map2x17 = 141.18f;
            var map2y17 = -80.35f;
            var map2x18 = 162.74f;
            var map2y18 = -74.16f;
            var map2x19 = 157.55f;
            var map2y19 = -80.49f;
            var map2x20 = 170.43f;
            var map2y20 = -73.73f;
            var map2x21 = 181.88f;
            var map2y21 = -75.94f;
            var map2x22 = 173.56f;
            var map2y22 = -69.03f;
            var map2x23 = 172.76f;
            var map2y23 = -80.18f;
            var map2x24 = 172.87f;
            var map2y24 = -86.53f;
            var map2x25 = 160.4f;
            var map2y25 = -88.85f;
            var map2x26 = 169.3f;
            var map2y26 = -91.4f;
            var map2x27 = 151.37f;
            var map2y27 = -90.22f;
            var map2x28 = 151.78f;
            var map2y28 = -74.52f;


            //Map 2
            var map2bag1 = Instantiate(moneyBagPrefab, new Vector3(map2x1, map2y1, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag1);

            var map2bag2 = Instantiate(moneyBagPrefab, new Vector3(map2x2, map2y2, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag2);

            var map2bag3 = Instantiate(moneyBagPrefab, new Vector3(map2x3, map2y3, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag3);

            var map2bag4 = Instantiate(moneyBagPrefab, new Vector3(map2x4, map2y4, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag4);

            var map2bag5 = Instantiate(moneyBagPrefab, new Vector3(map2x5, map2y5, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag5);

            var map2bag6 = Instantiate(moneyBagPrefab, new Vector3(map2x6, map2y6, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag6);

            var map2bag7 = Instantiate(moneyBagPrefab, new Vector3(map2x7, map2y7, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag7);

            var map2bag8 = Instantiate(moneyBagPrefab, new Vector3(map2x8, map2y8, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag8);

            var map2bag9 = Instantiate(moneyBagPrefab, new Vector3(map2x9, map2y9, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag9);

            var map2bag10 = Instantiate(moneyBagPrefab, new Vector3(map2x10, map2y10, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag10);

            var map2bag11 = Instantiate(moneyBagPrefab, new Vector3(map2x11, map2y11, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag11);

            var map2bag12 = Instantiate(moneyBagPrefab, new Vector3(map2x12, map2y12, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag12);

            var map2bag13 = Instantiate(moneyBagPrefab, new Vector3(map2x13, map2y13, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag13);

            var map2bag14 = Instantiate(moneyBagPrefab, new Vector3(map2x14, map2y14, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag14);

            var map2bag15 = Instantiate(moneyBagPrefab, new Vector3(map2x15, map2y15, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag15);

            var map2bag16 = Instantiate(moneyBagPrefab, new Vector3(map2x16, map2y16, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag16);

            var map2bag17 = Instantiate(moneyBagPrefab, new Vector3(map2x17, map2y17, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag17);

            var map2bag18 = Instantiate(moneyBagPrefab, new Vector3(map2x18, map2y18, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag18);

            var map2bag19 = Instantiate(moneyBagPrefab, new Vector3(map2x19, map2y19, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag19);

            var map2bag20 = Instantiate(moneyBagPrefab, new Vector3(map2x20, map2y20, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag20);

            var map2bag21 = Instantiate(moneyBagPrefab, new Vector3(map2x21, map2y21, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag21);

            var map2bag22 = Instantiate(moneyBagPrefab, new Vector3(map2x22, map2y22, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag22);

            var map2bag23 = Instantiate(moneyBagPrefab, new Vector3(map2x23, map2y23, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag23);

            var map2bag24 = Instantiate(moneyBagPrefab, new Vector3(map2x24, map2y24, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag24);

            var map2bag25 = Instantiate(moneyBagPrefab, new Vector3(map2x25, map2y25, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag25);

            var map2bag26 = Instantiate(moneyBagPrefab, new Vector3(map2x26, map2y26, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag26);

            var map2bag27 = Instantiate(moneyBagPrefab, new Vector3(map2x27, map2y27, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag27);

            var map2bag28 = Instantiate(moneyBagPrefab, new Vector3(map2x28, map2y28, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag28);


            //Map 3
            var map3x1 = -143.53f;
            var map3y1 = 5.55f;
            var map3x2 = -137.43f;
            var map3y2 = 5.69f;
            var map3x3 = -138.81f;
            var map3y3 = 1.89f;
            var map3x4 = -146.07f;
            var map3y4 = 7.04f;
            var map3x5 = -153.72f;
            var map3y5 = 8.47f;
            var map3x6 = -145.68f;
            var map3y6 = -1.37f;
            var map3x7 = -134.82f;
            var map3y7 = -0.76f;
            var map3x8 = -140.5f;
            var map3y8 = 14.89f;
            var map3x9 = -153.9f;
            var map3y9 = -8.5f;
            var map3x10 = -157.18f;
            var map3y10 = -0.99f;
            var map3x11 = -154.15f;
            var map3y11 = 17.44f;
            var map3x12 = -160.23f;
            var map3y12 = 11.74f;
            var map3x13 = -160.71f;
            var map3y13 = -8.61f;
            var map3x14 = -140.24f;
            var map3y14 = -14.37f;
            var map3x15 = -132.54f;
            var map3y15 = -11.96f;
            var map3x16 = -121.67f;
            var map3y16 = -17f;
            var map3x17 = -127.84f;
            var map3y17 = -11.44f;
            var map3x18 = -121.47f;
            var map3y18 = -7.09f;
            var map3x19 = -126.99f;
            var map3y19 = -1.43f;
            var map3x20 = -122.09f;
            var map3y20 = 2.43f;
            var map3x21 = -129.67f;
            var map3y21 = 19.46f;
            var map3x22 = -118.93f;
            var map3y22 = 12.9f;
            var map3x23 = -127.04f;
            var map3y23 = 12.75f;
            var map3x24 = -122.43f;
            var map3y24 = 18.92f;

            //Map 3
            var map3bag1 = Instantiate(moneyBagPrefab, new Vector3(map3x1, map3y1, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag1);

            var map3bag2 = Instantiate(moneyBagPrefab, new Vector3(map3x2, map3y2, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag2);

            var map3bag3 = Instantiate(moneyBagPrefab, new Vector3(map3x3, map3y3, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag3);

            var map3bag4 = Instantiate(moneyBagPrefab, new Vector3(map3x4, map3y4, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag4);

            var map3bag5 = Instantiate(moneyBagPrefab, new Vector3(map3x5, map3y5, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag5);

            var map3bag6 = Instantiate(moneyBagPrefab, new Vector3(map3x6, map3y6, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag6);

            var map3bag7 = Instantiate(moneyBagPrefab, new Vector3(map3x7, map3y7, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag7);

            var map3bag8 = Instantiate(moneyBagPrefab, new Vector3(map3x8, map3y8, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag8);

            var map3bag9 = Instantiate(moneyBagPrefab, new Vector3(map3x9, map3y9, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag9);

            var map3bag10 = Instantiate(moneyBagPrefab, new Vector3(map3x10, map3y10, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag10);

            var map3bag11 = Instantiate(moneyBagPrefab, new Vector3(map3x11, map3y11, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag11);

            var map3bag12 = Instantiate(moneyBagPrefab, new Vector3(map3x12, map3y12, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag12);

            var map3bag13 = Instantiate(moneyBagPrefab, new Vector3(map3x13, map3y13, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag13);

            var map3bag14 = Instantiate(moneyBagPrefab, new Vector3(map3x14, map3y14, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag14);

            var map3bag15 = Instantiate(moneyBagPrefab, new Vector3(map3x15, map3y15, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag15);

            var map3bag16 = Instantiate(moneyBagPrefab, new Vector3(map3x16, map3y16, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag16);

            var map3bag17 = Instantiate(moneyBagPrefab, new Vector3(map3x17, map3y17, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag17);

            var map3bag18 = Instantiate(moneyBagPrefab, new Vector3(map3x18, map3y18, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag18);

            var map3bag19 = Instantiate(moneyBagPrefab, new Vector3(map3x19, map3y19, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag19);

            var map3bag20 = Instantiate(moneyBagPrefab, new Vector3(map3x20, map3y20, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag20);

            var map3bag21 = Instantiate(moneyBagPrefab, new Vector3(map3x21, map3y21, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag21);

            var map3bag22 = Instantiate(moneyBagPrefab, new Vector3(map3x22, map3y22, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag22);

            var map3bag23 = Instantiate(moneyBagPrefab, new Vector3(map3x23, map3y23, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag23);

            var map3bag24 = Instantiate(moneyBagPrefab, new Vector3(map3x24, map3y24, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag24);
        }

        private void OnServerConnect(NetworkConnection nc, ConnectMessage cm)
        {
            //*Debug.Log("New client connected: " + nc);
        }
    }
}