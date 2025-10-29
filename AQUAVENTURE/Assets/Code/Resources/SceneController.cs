using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGame(string game)
    {
        SceneManager.LoadScene(game);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
