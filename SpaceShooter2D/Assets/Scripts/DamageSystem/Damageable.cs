using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 2f;
    protected float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        // Debug.Log($"{gameObject.name} took {amount} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        // You can override this in subclasses for specific death behavior
        Destroy(gameObject);
    }
}
