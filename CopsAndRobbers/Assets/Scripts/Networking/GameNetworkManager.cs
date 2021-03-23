using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    
    /// @authors Nisath Mohamed Nasar and Naim Ahmed
    class GameNetworkManager : MonoBehaviour
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

        void OnClientConnect(NetworkConnection nc, ConnectMessage cm)
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
        void CmdSpawnMoneyBags()
        {
            //Map 1
            float map1x1 = 11.59f;
            float map1y1 = -0.75f;
            float map1x2 = 17.37f;
            float map1y2 = -1.1f;
            float map1x3 = 4.12f;
            float map1y3 = -0.8f;
            float map1x4 = 14.44f;
            float map1y4 = 9.33f;
            float map1x5 = -1.33f;
            float map1y5 = 2.95f;
            float map1x6 = -4.8f;
            float map1y6 = 13f;
            float map1x7 = 31.6f;
            float map1y7 = 13.55f;
            float map1x8 = 30.93f;
            float map1y8 = 21.64f;
            float map1x9 = 4.55f;
            float map1y9 = 9.89f;
            float map1x10 = 36.06f;
            float map1y10 =	30.54f;
            float map1x11 = 18.73f;
            float map1y11 =	27.28f;
            float map1x12 = 25.37f;
            float map1y12 =	30.72f;
            float map1x13 = 19.33f;
            float map1y13 =	20.03f;
            float map1x14 = -28.66f;
            float map1y14 =	-25.76f;
            float map1x15 = -8.57f;
            float map1y15 = -14.23f;
            float map1x16 = -18.06f;
            float map1y16 =	12.35f;
            float map1x17 = -22.47f;
            float map1y17 =	23.33f;
            float map1x18 = -13.51f;
            float map1y18 =	23.05f;
            float map1x19 = -24.78f;
            float map1y19 =	30.05f;
            float map1x20 = -5.42f;
            float map1y20 =	29.76f;
            float map1x21 = -5.24f;
            float map1y21 =	20.59f;
            float map1x22 = -18.16f;
            float map1y22 =	-21.08f;
            float map1x23 = -8.37f;
            float map1y23 =	-22.57f;
            float map1x24 = -28.76f;
            float map1y24 = -14.16f;

            
            //Map 1
            GameObject mbg1 = Instantiate(moneyBagPrefab, new Vector3(map1x1, map1y1, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg1);
            
            GameObject mbg2 = Instantiate(moneyBagPrefab, new Vector3(map1x2, map1y2, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg2);

            GameObject mbg3 = Instantiate(moneyBagPrefab, new Vector3(map1x3, map1y3, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg3);

            GameObject mbg4 = Instantiate(moneyBagPrefab, new Vector3(map1x4, map1y4, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg4);

            GameObject mbg5 = Instantiate(moneyBagPrefab, new Vector3(map1x5, map1y5, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg5);

            GameObject mbg6 = Instantiate(moneyBagPrefab, new Vector3(map1x6, map1y6, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg6);

            GameObject mbg7 = Instantiate(moneyBagPrefab, new Vector3(map1x7, map1y7, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg7);

            GameObject mbg8 = Instantiate(moneyBagPrefab, new Vector3(map1x8, map1y8, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg8);

            GameObject mbg9 = Instantiate(moneyBagPrefab, new Vector3(map1x9, map1y9, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg9);

            GameObject mbg10 = Instantiate(moneyBagPrefab, new Vector3(map1x10, map1y10, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg10);

            GameObject mbg11 = Instantiate(moneyBagPrefab, new Vector3(map1x11, map1y11, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg11);

            GameObject mbg12 = Instantiate(moneyBagPrefab, new Vector3(map1x12, map1y12, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg12);

            GameObject mbg13 = Instantiate(moneyBagPrefab, new Vector3(map1x13, map1y13, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg13);

            GameObject mbg14 = Instantiate(moneyBagPrefab, new Vector3(map1x14, map1y14, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg14);

            GameObject mbg15 = Instantiate(moneyBagPrefab, new Vector3(map1x15, map1y15, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg15);

            GameObject mbg16 = Instantiate(moneyBagPrefab, new Vector3(map1x16, map1y16, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg16);

            GameObject mbg17 = Instantiate(moneyBagPrefab, new Vector3(map1x17, map1y17, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg17);

            GameObject mbg18 = Instantiate(moneyBagPrefab, new Vector3(map1x18, map1y18, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg18);

            GameObject mbg19 = Instantiate(moneyBagPrefab, new Vector3(map1x19, map1y19, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg19);

            GameObject mbg20 = Instantiate(moneyBagPrefab, new Vector3(map1x20, map1y20, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg20);

            GameObject mbg21 = Instantiate(moneyBagPrefab, new Vector3(map1x21, map1y21, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg21);

            GameObject mbg22 = Instantiate(moneyBagPrefab, new Vector3(map1x22, map1y22, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg22);

            GameObject mbg23 = Instantiate(moneyBagPrefab, new Vector3(map1x23, map1y23, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg23);

            GameObject mbg24 = Instantiate(moneyBagPrefab, new Vector3(map1x24, map1y24, 0), Quaternion.identity);
            NetworkServer.Spawn(mbg24);
            
            
            
            //Map 2
            float map2x1 = 140.44f;
            float map2y1 = -61.23f;
            float map2x2 = 147.67f;
            float map2y2 = -61.31f;
            float map2x3 = 140.44f; 
            float map2y3 = -61.23f;
            float map2x4 = 140.41f; 
            float map2y4 = -45.73f;
            float map2x5 = 150.79f; 
            float map2y5 = -46.22f;
            float map2x6 = 162.26f; 
            float map2y6 = -45.57f;
            float map2x7 = 152.73f; 
            float map2y7 = -53.16f;
            float map2x8 = 161.86f; 
            float map2y8 = -57.26f;
            float map2x9 = 155.89f; 
            float map2y9 = -65.39f;
            float map2x10 = 171.24f; 
            float map2y10 = -48.06f;
            float map2x11 = 175.03f; 
            float map2y11 = -56.77f;
            float map2x12 = 182.37f; 
            float map2y12 = -62.6f;
            float map2x13 = 175.58f; 
            float map2y13 = -39.13f;
            float map2x14 = 162.68f; 
            float map2y14 = -66.03f;
            float map2x15 = 170.17f; 
            float map2y15 = -65.72f;
            float map2x16 = 140.97f; 
            float map2y16 = -73.94f;
            float map2x17 = 141.18f; 
            float map2y17 = -80.35f;
            float map2x18 = 162.74f; 
            float map2y18 = -74.16f;
            float map2x19 = 157.55f; 
            float map2y19 = -80.49f;
            float map2x20 = 170.43f; 
            float map2y20 = -73.73f;
            float map2x21 = 181.88f; 
            float map2y21 = -75.94f;
            float map2x22 = 173.56f; 
            float map2y22 = -69.03f;
            float map2x23 = 172.76f; 
            float map2y23 = -80.18f;
            float map2x24 = 172.87f; 
            float map2y24 = -86.53f;
            float map2x25 = 160.4f; 
            float map2y25 = -88.85f;
            float map2x26 = 169.3f; 
            float map2y26 = -91.4f;
            float map2x27 = 151.37f; 
            float map2y27 = -90.22f;
            float map2x28 = 151.78f; 
            float map2y28 = -74.52f;

            
            //Map 2
            GameObject map2bag1 = Instantiate(moneyBagPrefab, new Vector3(map2x1, map2y1, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag1);
            
            GameObject map2bag2 = Instantiate(moneyBagPrefab, new Vector3(map2x2, map2y2, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag2);

            GameObject map2bag3 = Instantiate(moneyBagPrefab, new Vector3(map2x3, map2y3, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag3);

            GameObject map2bag4 = Instantiate(moneyBagPrefab, new Vector3(map2x4, map2y4, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag4);

            GameObject map2bag5 = Instantiate(moneyBagPrefab, new Vector3(map2x5, map2y5, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag5);

            GameObject map2bag6 = Instantiate(moneyBagPrefab, new Vector3(map2x6, map2y6, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag6);

            GameObject map2bag7 = Instantiate(moneyBagPrefab, new Vector3(map2x7, map2y7, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag7);

            GameObject map2bag8 = Instantiate(moneyBagPrefab, new Vector3(map2x8, map2y8, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag8);

            GameObject map2bag9 = Instantiate(moneyBagPrefab, new Vector3(map2x9, map2y9, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag9);

            GameObject map2bag10 = Instantiate(moneyBagPrefab, new Vector3(map2x10, map2y10, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag10);

            GameObject map2bag11 = Instantiate(moneyBagPrefab, new Vector3(map2x11, map2y11, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag11);

            GameObject map2bag12 = Instantiate(moneyBagPrefab, new Vector3(map2x12, map2y12, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag12);

            GameObject map2bag13 = Instantiate(moneyBagPrefab, new Vector3(map2x13, map2y13, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag13);

            GameObject map2bag14 = Instantiate(moneyBagPrefab, new Vector3(map2x14, map2y14, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag14);

            GameObject map2bag15 = Instantiate(moneyBagPrefab, new Vector3(map2x15, map2y15, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag15);

            GameObject map2bag16 = Instantiate(moneyBagPrefab, new Vector3(map2x16, map2y16, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag16);

            GameObject map2bag17 = Instantiate(moneyBagPrefab, new Vector3(map2x17, map2y17, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag17);

            GameObject map2bag18 = Instantiate(moneyBagPrefab, new Vector3(map2x18, map2y18, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag18);

            GameObject map2bag19 = Instantiate(moneyBagPrefab, new Vector3(map2x19, map2y19, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag19);

            GameObject map2bag20= Instantiate(moneyBagPrefab, new Vector3(map2x20, map2y20, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag20);

            GameObject map2bag21 = Instantiate(moneyBagPrefab, new Vector3(map2x21, map2y21, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag21);

            GameObject map2bag22 = Instantiate(moneyBagPrefab, new Vector3(map2x22, map2y22, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag22);

            GameObject map2bag23 = Instantiate(moneyBagPrefab, new Vector3(map2x23, map2y23, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag23);

            GameObject map2bag24 = Instantiate(moneyBagPrefab, new Vector3(map2x24, map2y24, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag24);
            
            GameObject map2bag25 = Instantiate(moneyBagPrefab, new Vector3(map2x25, map2y25, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag25);

            GameObject map2bag26 = Instantiate(moneyBagPrefab, new Vector3(map2x26, map2y26, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag26);

            GameObject map2bag27 = Instantiate(moneyBagPrefab, new Vector3(map2x27, map2y27, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag27);

            GameObject map2bag28 = Instantiate(moneyBagPrefab, new Vector3(map2x28, map2y28, 0), Quaternion.identity);
            NetworkServer.Spawn(map2bag28);
            
            
            //Map 3
            float map3x1 = -143.53f; 
            float map3y1 = 5.55f;
            float map3x2 = -137.43f; 
            float map3y2 = 5.69f;
            float map3x3 = -138.81f; 
            float map3y3 =	1.89f;
            float map3x4 = -146.07f; 
            float map3y4 =	7.04f;
            float map3x5 = -153.72f; 
            float map3y5 =	8.47f;
            float map3x6 = -145.68f; 
            float map3y6 =	-1.37f;
            float map3x7 = -134.82f; 
            float map3y7 =	-0.76f;
            float map3x8 = -140.5f; 
            float map3y8 =	14.89f;
            float map3x9 = -153.9f; 
            float map3y9 =	-8.5f;
            float map3x10 = -157.18f; 
            float map3y10 =	-0.99f;
            float map3x11 = -154.15f; 
            float map3y11 =	17.44f;
            float map3x12 = -160.23f; 
            float map3y12 =	11.74f;
            float map3x13 = -160.71f; 
            float map3y13 =	-8.61f;
            float map3x14 = -140.24f; 
            float map3y14 =	-14.37f;
            float map3x15 = -132.54f; 
            float map3y15 =	-11.96f;
            float map3x16 = -121.67f; 
            float map3y16 =	-17f;
            float map3x17 = -127.84f; 
            float map3y17 =	-11.44f;
            float map3x18 = -121.47f; 
            float map3y18 =	-7.09f;
            float map3x19 = -126.99f; 
            float map3y19 =	-1.43f;
            float map3x20 = -122.09f; 
            float map3y20 =	2.43f;
            float map3x21 = -129.67f; 
            float map3y21 =	19.46f;
            float map3x22 = -118.93f; 
            float map3y22 =	12.9f;
            float map3x23 = -127.04f; 
            float map3y23 =	12.75f;
            float map3x24 = -122.43f; 
            float map3y24 =	18.92f;

            //Map 3
            GameObject map3bag1 = Instantiate(moneyBagPrefab, new Vector3(map3x1, map3y1, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag1);
            
            GameObject map3bag2 = Instantiate(moneyBagPrefab, new Vector3(map3x2, map3y2, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag2);

            GameObject map3bag3 = Instantiate(moneyBagPrefab, new Vector3(map3x3, map3y3, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag3);

            GameObject map3bag4 = Instantiate(moneyBagPrefab, new Vector3(map3x4, map3y4, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag4);

            GameObject map3bag5 = Instantiate(moneyBagPrefab, new Vector3(map3x5, map3y5, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag5);

            GameObject map3bag6 = Instantiate(moneyBagPrefab, new Vector3(map3x6, map3y6, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag6);

            GameObject map3bag7 = Instantiate(moneyBagPrefab, new Vector3(map3x7, map3y7, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag7);

            GameObject map3bag8 = Instantiate(moneyBagPrefab, new Vector3(map3x8, map3y8, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag8);

            GameObject map3bag9 = Instantiate(moneyBagPrefab, new Vector3(map3x9, map3y9, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag9);

            GameObject map3bag10 = Instantiate(moneyBagPrefab, new Vector3(map3x10, map3y10, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag10);

            GameObject map3bag11 = Instantiate(moneyBagPrefab, new Vector3(map3x11, map3y11, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag11);

            GameObject map3bag12 = Instantiate(moneyBagPrefab, new Vector3(map3x12, map3y12, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag12);

            GameObject map3bag13 = Instantiate(moneyBagPrefab, new Vector3(map3x13, map3y13, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag13);

            GameObject map3bag14 = Instantiate(moneyBagPrefab, new Vector3(map3x14, map3y14, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag14);

            GameObject map3bag15 = Instantiate(moneyBagPrefab, new Vector3(map3x15, map3y15, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag15);

            GameObject map3bag16 = Instantiate(moneyBagPrefab, new Vector3(map3x16, map3y16, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag16);

            GameObject map3bag17 = Instantiate(moneyBagPrefab, new Vector3(map3x17, map3y17, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag17);

            GameObject map3bag18 = Instantiate(moneyBagPrefab, new Vector3(map3x18, map3y18, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag18);

            GameObject map3bag19 = Instantiate(moneyBagPrefab, new Vector3(map3x19, map3y19, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag19);

            GameObject map3bag20= Instantiate(moneyBagPrefab, new Vector3(map3x20, map3y20, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag20);

            GameObject map3bag21 = Instantiate(moneyBagPrefab, new Vector3(map3x21, map3y21, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag21);

            GameObject map3bag22 = Instantiate(moneyBagPrefab, new Vector3(map3x22, map3y22, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag22);

            GameObject map3bag23 = Instantiate(moneyBagPrefab, new Vector3(map3x23, map3y23, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag23);

            GameObject map3bag24 = Instantiate(moneyBagPrefab, new Vector3(map3x24, map3y24, 0), Quaternion.identity);
            NetworkServer.Spawn(map3bag24);
            
            
            
            
        }

        void OnServerConnect(NetworkConnection nc, ConnectMessage cm)
        {
            //*Debug.Log("New client connected: " + nc);
        }

    }
}
