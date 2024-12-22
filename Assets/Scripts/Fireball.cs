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
        gameObject.SetActive(false); // Deactivate bullet on collision
    }
}
