using UnityEngine;

public class EnemyShip : Damageable
{
    private int health = 2;
    private Transform playerTransform;
    private float speed = 1f;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // PointToPlayer();
        Move();
    }


    public void Move()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void PointToPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
