using UnityEngine;

public class Asteroid : Damageable
{
    public Transform spriteTransform;
    public float speed = 3f;
    public LayerMask damageableLayerMask;

    private Vector3 movDir = new Vector3(0, -1, 0);

    void Update()
    {
        RotateSprite();
        Move();
    }

    void Move()
    {
        transform.position += movDir * speed * Time.deltaTime;
    }

    void RotateSprite()
    {
        spriteTransform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto está na Layer correta
        if (((1 << other.gameObject.layer) & damageableLayerMask) != 0)
        {
            Damageable damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(1f);
                Destroy(gameObject);
            }
        }
    }
}
