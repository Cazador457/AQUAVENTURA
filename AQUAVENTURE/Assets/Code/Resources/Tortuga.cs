using UnityEngine;
using System.Collections;

public class Tortuga : MonoBehaviour
{
    public UI ui;
    public RectTransform pointA;
    public RectTransform pointB;

    [Header("Movimiento")]
    public float moveDuration = 2f;

    private RectTransform rectTransform;
    private float timer = 0f;
    private bool goingToB = true;
    public bool isRunnig = true;

    void Start()
    {
        StartCoroutine(GameTime());
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float t = Mathf.Clamp01(timer / moveDuration);

        if (goingToB)
            rectTransform.anchoredPosition = Vector2.Lerp(pointA.anchoredPosition, pointB.anchoredPosition, t);
        else
            rectTransform.anchoredPosition = Vector2.Lerp(pointB.anchoredPosition, pointA.anchoredPosition, t);

        if (t >= 1f)
        {
            if (goingToB)
            {
                ui.RestLife();
            }
            else
            {
                enabled = false;
            }
        }
    }
    IEnumerator GameTime()
    {
        while (isRunnig)
        {
            yield return new WaitForSeconds(0.5f);
            timer++;
            Debug.Log($"{timer}");
        }
    }
}
