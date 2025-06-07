using UnityEngine;
using DG.Tweening;
using System; // Importante para usar DOTween

[RequireComponent(typeof(Collider2D))]
public abstract class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] protected float maxHealth = 2f;
    protected float currentHealth;

    public float CurrentHealth => currentHealth; // Public read-only access

    [Header("Damage Feedback")]
    [SerializeField] private float feedbackScale = 1.2f;
    [SerializeField] private float feedbackDuration = 0.15f;
    [SerializeField] private Color damageColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private Color originalColor;

    public static Action Death;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        originalScale = transform.localScale;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Feedback visual de dano
        PlayDamageFeedback();

        if (currentHealth <= 0)
        {
            Death?.Invoke();
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    private void PlayDamageFeedback()
    {
        // Escala (pulsar)
        transform.DOKill(); // Cancela qualquer tween anterior
        transform.localScale = originalScale;
        transform.DOScale(originalScale * feedbackScale, feedbackDuration / 2)
                 .SetLoops(2, LoopType.Yoyo);

        // Cor (flash vermelho)
        if (spriteRenderer != null)
        {
            spriteRenderer.DOKill();
            spriteRenderer.color = originalColor;
            spriteRenderer.DOColor(damageColor, feedbackDuration / 2)
                          .SetLoops(2, LoopType.Yoyo);
        }
    }
}
