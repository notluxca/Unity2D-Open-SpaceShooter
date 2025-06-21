using UnityEngine;
using System.Collections;
using System;

public enum BulletType
{
    SINGLE,
    TRIPLE
}

public class ShootController : MonoBehaviour
{
    public GameObject singleBulletPrefab;
    public GameObject tripleBulletPrefab;
    public BulletType bulletType = BulletType.SINGLE;

    private Coroutine tripleShotCoroutine;
    public static Action OnShoot;

    public void Shoot()
    {
        GameObject prefabToUse = bulletType == BulletType.SINGLE ? singleBulletPrefab : tripleBulletPrefab;
        Instantiate(prefabToUse, transform.position, Quaternion.identity);
        OnShoot.Invoke();
    }

    public void SetBulletType(BulletType type)
    {
        bulletType = type;
    }

    public void ActivateTripleShot(float duration)
    {
        if (tripleShotCoroutine != null)
        {
            StopCoroutine(tripleShotCoroutine); // Reinicia caso já esteja ativo
        }

        tripleShotCoroutine = StartCoroutine(TripleShotRoutine(duration));
    }

    private IEnumerator TripleShotRoutine(float duration)
    {
        SetBulletType(BulletType.TRIPLE);
        yield return new WaitForSeconds(duration);
        SetBulletType(BulletType.SINGLE);
        tripleShotCoroutine = null;
    }
}
