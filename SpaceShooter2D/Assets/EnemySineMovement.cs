using UnityEngine;

public class EnemySineMovement : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 0.5f;
    public float frequency = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = transform.position.x - speed * Time.deltaTime;
        float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(y, x, transform.position.z);
    }
}
