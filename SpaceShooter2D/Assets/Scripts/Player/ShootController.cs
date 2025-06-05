using UnityEngine;

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

    public void Shoot()
    {
        var bullet = Instantiate(bulletType == BulletType.SINGLE ? singleBulletPrefab : tripleBulletPrefab, transform.position, Quaternion.identity);
    }

    public void SetBulletType(BulletType bulletType)
    {
        this.bulletType = bulletType;
    }
}
