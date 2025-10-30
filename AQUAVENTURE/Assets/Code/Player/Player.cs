using UnityEngine;

public class Player : MonoBehaviour
{
    public UI ui;

    public float speed;
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public GameObject bulletPref;
    public Transform firePoint;
    public float bulletSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Shoot();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            GameObject bullet = PoolManager.Instance.SpawnFromPool("Bullet", firePoint.position, firePoint.rotation);
            if (bullet != null)
            {
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.linearVelocity = firePoint.up * 10f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ui.RestLife();
        }
    }
}
