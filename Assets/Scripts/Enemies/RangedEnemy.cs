using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingInterval = 2f; // Time between shots
    private float shootingCooldown;

   // public float moveSpeed = 2f; // Speed of vertical movement
    public float moveRange = 2f; // How far up/down the enemy will move
    private Vector3 initialPosition; // Store the starting position of the enemy
    private bool movingUp = true; // Control movement direction

    private void Start()
    {
        shootingCooldown = shootingInterval; // Initialize cooldown

        // Set the initial position on the right side of the screen
        initialPosition = transform.position;
    }

    private void Update()
    {

        MoveVertically(); // Handle vertical movement
        ShootAtPlayer();  // Handle shooting logic
    }

    void MoveVertically()
    {
        // Check the vertical movement logic (up and down)
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= initialPosition.y + moveRange)
            {
                movingUp = false; 
            }
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y <= initialPosition.y - moveRange)
            {
                movingUp = true; 
            }
        }
    }

    void ShootAtPlayer()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            shootingCooldown -= Time.deltaTime;
            if (shootingCooldown <= 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Vector2 direction = (target.position - firePoint.position).normalized;
                rb.velocity = direction * 5f; 
                shootingCooldown = shootingInterval; 
            }
        }
    }
}
