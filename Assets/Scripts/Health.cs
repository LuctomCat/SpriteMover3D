using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;

    // Add this:
    public Action onDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (!IsAlive())
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void Die()
    {
        // Notify any listeners
        onDeath?.Invoke();

        // Existing death behavior
        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
