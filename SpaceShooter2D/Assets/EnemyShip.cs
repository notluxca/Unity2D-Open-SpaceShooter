using System.Collections;
using UnityEngine;

public class EnemyShip : Damageable
{
    [SerializeField] private int health = 2;
    [SerializeField] private float verticalSpeed = 2f;
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float horizontalAmplitude = 3f;
    [SerializeField] private GameObject BulletPrefab;

    private Camera mainCamera;
    private float startX;
    private float timeOffset;

    void Start()
    {
        mainCamera = Camera.main;
        startX = transform.position.x;
        timeOffset = Random.Range(0f, 2f * Mathf.PI); // Para variar o movimento entre inimigos
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {
        Move();

        if (IsOutOfScreen())
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        float newY = transform.position.y - verticalSpeed * Time.deltaTime;

        // Movimento horizontal oscilante
        float newX = startX + Mathf.Sin(Time.time * horizontalSpeed + timeOffset) * horizontalAmplitude;

        // Limita dentro da tela
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.5f;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.5f;
        newX = Mathf.Clamp(newX, minX, maxX);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private bool IsOutOfScreen()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        return screenPos.y < 0;
    }

    protected override void Die()
    {
        FindAnyObjectByType<ScoreManager>().AddScore(10);
        base.Die();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(3f);
        }
    }
}
