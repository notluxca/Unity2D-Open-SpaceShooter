using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 smoothVel;
    public float smoothValue = 0.1f;
    private float initialYOffset;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        initialYOffset = transform.position.y - playerTransform.position.y;
    }

    void FixedUpdate()
    {
        if (playerTransform == null) return;
        float targetY = playerTransform.position.y + initialYOffset;
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothVel, smoothValue);
    }
}
