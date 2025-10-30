using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public Transform spawnLeft;
    public Transform spawnRight;
    public float respawnDelay = 2f;

    private bool spawnRightDirection = true;
    private GameObject currentEnemy;

    void Start()
    {
        SpawnEnemy(spawnRightDirection);
    }

    void Update()
    {
        
    }
    void SpawnEnemy(bool fromLeft)
    {
        currentEnemy = PoolManager.Instance.SpawnFromPool("Enemy",
            fromLeft ? spawnLeft.position : spawnRight.position,
            Quaternion.identity);

        if (currentEnemy != null)
        {
            Enemy enemy = currentEnemy.GetComponent<Enemy>();

            enemy.movingRight = fromLeft;

            currentEnemy.SetActive(true);
        }
    }
    public void OnEnemyDied(Enemy enemy)
    {
        spawnRightDirection = !spawnRightDirection;

        StartCoroutine(RespawnNext());
    }
    IEnumerator RespawnNext()
    {
        yield return new WaitForSeconds(respawnDelay);

        SpawnEnemy(spawnRightDirection);
    }
}
