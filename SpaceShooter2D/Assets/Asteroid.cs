using UnityEngine;

public class Asteroid : Damageable
{
    public Transform spriteTransform;
    public float speed = 3f;
    Vector3 movDir = new Vector3(0, -1, 0);

    void Move()
    {
        transform.position += movDir * speed * Time.deltaTime;
    }


    void Update()
    {
        RotateSprite();
        Move();
    }

    private void RotateSprite()
    {
        spriteTransform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
