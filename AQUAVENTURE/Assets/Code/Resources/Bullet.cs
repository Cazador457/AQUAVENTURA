using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>()?.Die();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DisableBullet), 3f);
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
