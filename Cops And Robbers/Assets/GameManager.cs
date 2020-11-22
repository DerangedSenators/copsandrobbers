using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Hannah
 */

/// <summary>
/// This Script is used for testing Spawn of players and changing of teams
/// </summary>
public class GameManager : MonoBehaviour
{
    private GameObject CopPrefab;
    private GameObject RobberPrefab;
    private GameObject player;
    private GameObject spawnButton;
    private int teamID;
    private Vector2 position;

    /// <summary>
    /// This function spawns a player with the Cop Prefab at 0,0
    /// </summary>
    public void SpawnPlayer() {
        position = new Vector2(0, 0);
        player = Instantiate(CopPrefab, position, Quaternion.identity);
        teamID = 0;
        spawnButton.SetActive(false);
    }

    /// <summary>
    /// This function destroys the old clone object and spawns opposite prefab at same position
    /// </summary>
    public void ChangeTeam() {
        //if a cop change to robber
        if (teamID == 0) {
            teamID = 1;
            Debug.Log(player.transform.position);
            position = player.transform.position;
            Destroy(this.player); 
            player = Instantiate(RobberPrefab, position, Quaternion.identity);
        }
        //else if a robber change to cop
        else if (teamID == 1) {
            teamID = 0;
            position = player.transform.position;
            Destroy(this.player);
            player = Instantiate(CopPrefab, position, Quaternion.identity);
        }
    }

}
