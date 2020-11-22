using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class TeamManager : MonoBehaviour
    {

        private int team;
        static bool onATeam;
        private GameObject player;

        //Start with no team value
        private void Start() {
            onATeam = false;
        }

        //A Network Manager sends over the value where we assign the teams
        void SetTeam(int team)
        {
            this.team = team;
            onATeam = true;
            if (team == 1) {
                //Assign cop prefab
                player = new GameObject("Cop");
                player = GameObject.Instantiate(player, transform.position, Quaternion.identity) as GameObject;
            }

            if (team == 0) {
                //Assign Robber prefab
                player = new GameObject("Robber");
                player = GameObject.Instantiate(player, transform.position, Quaternion.identity) as GameObject;
            }
  
        }

    }
}
