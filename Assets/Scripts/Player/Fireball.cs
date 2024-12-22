using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime = 2f;

    void OnEnable()
    {
        Invoke(nameof(Deactivate), lifetime);
    }

    void OnDisable()
    {
        CancelInvoke(); // Prevent multiple invocations
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with something!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage();  
            }
             Score.instance.UpdateScore();

        }

    
        gameObject.SetActive(false); 

    }

}
