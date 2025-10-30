using UnityEngine;

public class Coral : MonoBehaviour
{
    public UI ui;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.RestLife();
        }
    }
}
