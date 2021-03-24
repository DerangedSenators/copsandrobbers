///<summary>For buttons that lead to the main menu, also disables any network connection to prevent sudden attempts to reconnect.</summary>
///@author Elliot Willis

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    public GameObject networkManager;
    public void Load()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(networkManager);
    }
}