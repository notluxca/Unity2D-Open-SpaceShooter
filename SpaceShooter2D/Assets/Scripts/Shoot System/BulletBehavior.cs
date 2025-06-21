using System;
using NUnit.Framework;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 viewportPos;
    public LayerMask targetLayer;
    public static Action hit;

    private void OnEnable()
    {
        // Invoke("DestroySelf", 5f); // segurança extra, mesmo que o objeto não saia da tela
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        CheckScreenBoundariesAndDestroy();
    }


    // Fix: this spagetti is caused by the two types of bullets and different conditions to destroy them
    void CheckScreenBoundariesAndDestroy()
    {
        viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x < 0 || viewportPos.x > 1) // If projectile left the horizontal bounds of screen
        {
            if (transform.parent != null && transform.parent.childCount == 1) // If it has a parent and it is the only child
            {
                Destroy(transform.parent.gameObject);
            }
            else if (transform.parent != null) // If it has a parent but is not the only child
            {
                Destroy(gameObject);
            }
            else if (transform.parent == null && transform.childCount == 0) // If it has no parent and no children just destroy itself
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject); // safety last? // if nothing destroy anyways
            }
        }
        if (viewportPos.y > 1)
        {
            if (transform.parent != null) Destroy(transform.parent.gameObject);
            else Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((targetLayer.value & (1 << other.gameObject.layer)) == 0)
            return;

        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1f);
            hit?.Invoke();
            Destroy(gameObject);
        }
    }
}
