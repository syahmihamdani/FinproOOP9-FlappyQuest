using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public GameObject player;

    public int poolSize = 10; // Number of bullets in the pool
    private List<GameObject> bulletPool; // Pool of bullets

    Vector2 lookDirection;
    float lookAngle;
    AudioManager audioManager;

    private void Awake(){

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    void Start()
    {
        // Initialize the bullet pool
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Deactivate bullet initially
            bulletPool.Add(bullet);
        }
    }

    void Update()
    {
        // Calculate aim direction and rotation
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        // Fire bullet on left mouse button click
        if (Input.GetMouseButtonDown(0))
        {

            Shoot();
        }
    }

    void Shoot()
    {
        audioManager.PlaySFX(audioManager.shoot);
        // Get an inactive bullet from the pool
        GameObject bullet = GetPooledBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            bullet.SetActive(true);

            // Set bullet velocity
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }

    GameObject GetPooledBullet()
    {
        // Find the first inactive bullet in the pool
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null; // No available bullet
    }
}
