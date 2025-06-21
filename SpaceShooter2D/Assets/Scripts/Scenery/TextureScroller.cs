using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TextureScroller : MonoBehaviour
{
    [Tooltip("Velocidade de descida do sprite.")]
    public float scrollSpeed = 1f;

    [Tooltip("Altura total do sprite antes de reiniciar (deve ser igual à altura do sprite em world units).")]
    public float resetHeight = 10f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y <= startPosition.y - resetHeight)
        {
            transform.position = startPosition;
        }
    }
}
