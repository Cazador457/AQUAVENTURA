using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int maxLife = 3;
    public int currentLife;
    public Image[] lifeSprite;
    public float timer = 0f;
    public int score = 0;
    public Transform respawnPosition;
    public GameObject Player;

    public bool isRunnig = true;

    void Start()
    {
        currentLife = maxLife;
        CurrentLife();
        ResetScore();
        CurrentScore();
        StartCoroutine(GameTime());
    }
    public void RestLife()
    {
        if (currentLife < 0) return;
        currentLife--;
        CurrentLife();
    }
    public void CurrentLife()
    {
        for(int i = 0; i < lifeSprite.Length; i++)
        {
            lifeSprite[i].enabled = i < currentLife;
        }
    }

    IEnumerator GameTime()
    {
        while (isRunnig)
        {
            yield return new WaitForSeconds(1f);
            timer++;
        }
    }
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
    }
}
