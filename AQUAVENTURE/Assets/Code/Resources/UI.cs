using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameManager gameManager;
    public SceneController sceneController;

    public GameObject panel;
    public string reset;

    public TextMeshProUGUI scoreText;
    public int score = 0;

    public int maxLife = 3;
    public int currentLife;
    public Image[] lifeSprite;

    public float timer = 0f;

    public bool isRunnig = true;
    void Start()
    {
        StartCoroutine(GameTime());
        panel.SetActive(false);
        currentLife = maxLife;
        CurrentLife();
        CurrentScore();
    }
    void Update()
    {
        EndGameTime();
    }

    //Life
    public void RestLife()
    {
        currentLife--;
        if (currentLife <= 0)
        {
            StartCoroutine(ResetGame());
        }
        if (currentLife >= 0)
        {
            StartCoroutine(Respawn());
        }
        CurrentLife();
    }
    public void CurrentLife()
    {
        for (int i = 0; i < lifeSprite.Length; i++)
        {
            lifeSprite[i].enabled = i < currentLife;
        }
    }
    IEnumerator Respawn()
    {
        gameManager.player.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameManager.player.transform.position = gameManager.respawnPosition.position;
        gameManager.player.SetActive(true);
    }

    //Time
    IEnumerator GameTime()
    {
        while (isRunnig)
        {
            yield return new WaitForSeconds(0.5f);
            timer++;
            Debug.Log($"{timer}");
        }
    }

    void EndGameTime()
    {
        if (timer >= 35f)
        {
            StartCoroutine(ResetGame());
        }
    }
    IEnumerator ResetGame()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        ResetTime();
        ResetScore();
        sceneController.GameOver(reset);
    }
    public void ResetTime()
        {
            timer = 0;
        }
    //Score
    public void AddScore(int amount)
    {
        score += amount;
        CurrentScore();
    }
    private void CurrentScore()
    {
        scoreText.text = $"{score}";
    }
    public void ResetScore()
    {
        score = 0;
        CurrentScore();
    }
}
