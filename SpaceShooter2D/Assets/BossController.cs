using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class BossController : Damageable
{
    [Header("Sprite Rotation")]
    public Transform spriteTransform;
    public float rotateSpeed = 1f;
    public static Action OnBossDeath;

    [Header("Attack Settings")]
    [SerializeField] private List<GameObject> bulletPrefabs; // Prefabs diferentes de tiros
    [SerializeField] private Transform firePoint;            // Ponto de onde saem os tiros
    [SerializeField] private float timeBetweenShots = 0.5f;
    [SerializeField] private float cooldownBetweenPatterns = 2f;
    [SerializeField] private int minShotsPerPattern = 3;
    [SerializeField] private int maxShotsPerPattern = 6;

    private Coroutine attackRoutine;

    void Start()
    {
        attackRoutine = StartCoroutine(AttackPatternRoutine());
    }

    void Update()
    {
        RotateSpaceshipSprite();
    }

    private void RotateSpaceshipSprite()
    {
        spriteTransform.Rotate(new Vector3(0, 0, 45) * rotateSpeed * Time.deltaTime);
    }

    private IEnumerator AttackPatternRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            // Escolhe um tipo de tiro aleatório
            GameObject chosenBullet = bulletPrefabs[UnityEngine.Random.Range(0, bulletPrefabs.Count)];
            int shotsToFire = UnityEngine.Random.Range(minShotsPerPattern, maxShotsPerPattern + 1);

            for (int i = 0; i < shotsToFire; i++)
            {
                Instantiate(chosenBullet, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(timeBetweenShots);
            }

            yield return new WaitForSeconds(cooldownBetweenPatterns);
        }
    }

    private void OnDestroy()
    {
        if (OnBossDeath != null)
            OnBossDeath.Invoke();
        if (attackRoutine != null)
            StopCoroutine(attackRoutine);
    }
}
