using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySpawner spawner;
    public UI ui;
    public int value = 500;

    public float speed = 3f;
    public float leftLimit = -3f;
    public float rightLimit = 3f;

    public bool movingRight = true;

    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Move()
    {
        if (movingRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x >= rightLimit)
            movingRight = false;
        else if (transform.position.x <= leftLimit)
            movingRight = true;
    }
    public void Die()
    {
        ui.AddScore(value);
        gameObject.SetActive(false);
        spawner.OnEnemyDied(this);
    }
}
