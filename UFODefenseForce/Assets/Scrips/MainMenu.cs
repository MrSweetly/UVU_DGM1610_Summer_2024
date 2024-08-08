using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int ScenetoLoad;
    
    public void StartGame()
    {
        SceneManager.LoadScene(ScenetoLoad); // Load selected (int) scene
        Debug.Log("Scene Loaded!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
