using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public void GameOver(string reset)
    {
        SceneManager.LoadScene(reset);
    }


}
