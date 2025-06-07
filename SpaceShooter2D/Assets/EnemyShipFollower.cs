using UnityEngine;

public class EnemyShipFollower : Damageable
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private LayerMask playerLayerMask;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
    }

    void Update()
    {
        if (player == null) return;

        // Move suavemente em direção ao player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Rotaciona suavemente a nave para olhar na direção do player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    protected override void Die()
    {
        FindAnyObjectByType<ScoreManager>().AddScore(10);
        Debug.Log("Enemy Ship Died");
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se colidiu com algo na layer do player
        if ((playerLayerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            other.GetComponent<Damageable>().TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
