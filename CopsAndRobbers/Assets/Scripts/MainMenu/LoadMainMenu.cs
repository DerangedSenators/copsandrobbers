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