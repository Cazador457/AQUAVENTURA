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
    public int maxLife = 3;
    public int currentLife;
    public Image[] lifeSprite;
    public float timer = 0f;
    public float end = 2f;
    public int score = 0;

    public bool isRunnig = true;
    void Start()
    {
        panel.SetActive(false);
        currentLife = maxLife;
        CurrentLife();
        ResetScore();
        CurrentScore();
        StartCoroutine(ResetGame());
        ResetTime();
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
    }
    public void RestLife()
    {
        if (currentLife < 0) return;
        currentLife--;
        CurrentLife();
    }
    public void CurrentLife()
    {
        for (int i = 0; i < lifeSprite.Length; i++)
        {
            lifeSprite[i].enabled = i < currentLife;
        }
    }
    /*IEnumerator GameTime()
    {
        while (isRunnig)
        {
            yield return new WaitForSeconds(1f);
            timer++;
            score++;
            Debug.Log($"{timer}");
        }
    }*/
    public void ResetTime()
    {
        timer = 0;
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
    void RestTime()
    {
        timer+= Time.deltaTime;
        if (timer >= 10f)
        {
            StartCoroutine(ResetGame());
        }
    }
    IEnumerator ResetGame()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        sceneController.GameOver(reset);
    }
}
