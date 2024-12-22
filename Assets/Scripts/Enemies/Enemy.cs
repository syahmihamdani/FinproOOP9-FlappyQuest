using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;
    public float moveSpeed = 2f;
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        currentHealth = maxHealth;
    }

    private void Update()
    {
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            DestroyEnemy(); // Destroy the enemy when health is zero
        }
    }

    protected void DestroyEnemy()
    {
        // Optionally play destruction animation or sound
        Destroy(gameObject);  // Destroy the enemy game object
    }
}
