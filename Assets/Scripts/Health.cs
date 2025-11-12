using UnityEngine;
//fix
public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0f, currentHealth);

        if (currentHealth <= 0f)
            Die();
    }

    public virtual void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }

    // Call Death Component
    protected virtual void Die()
    {
        Death death = GetComponent<Death>();
        if (death != null)
            death.Die();
        else
            Destroy(gameObject);
    }

    public bool IsAlive()
    {
        return currentHealth > 0f;
    }
}
