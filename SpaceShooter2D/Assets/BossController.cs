using UnityEngine;

public class BossController : Damageable
{

    public Transform spriteTransform;
    public float rotateSpeed;

    void Start()
    {

    }

    void Update()
    {
        RotateSpaceshipSprite();
    }

    private void RotateSpaceshipSprite()
    {
        spriteTransform.Rotate(new Vector3(0, 0, 45) * rotateSpeed * Time.deltaTime);
    }
}
