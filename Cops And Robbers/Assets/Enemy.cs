using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;

        if (currentHealth <= 0f) {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("death onto you");
        Destroy(gameObject);
    }
}
