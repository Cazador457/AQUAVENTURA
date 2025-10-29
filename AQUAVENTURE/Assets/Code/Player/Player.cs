using UnityEngine;

public class Player : MonoBehaviour
{
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
        
    }
}
