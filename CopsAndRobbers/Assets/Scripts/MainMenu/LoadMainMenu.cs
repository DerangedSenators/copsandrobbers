using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("MainMenu");
    }
}