using System;
using UnityEngine;

public class PlayerController : Damageable
{
    [SerializeField] private float velocity = 5f;

    private Vector2 screenBounds;
    private float dirX;
    private float playerHalfWidth;
    private ShootController shootController;


    protected override void Awake()
    {
        base.Awake();
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        shootController = GetComponent<ShootController>();
    }

    private void Start()
    {
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBounds = new Vector2(screenTopRight.x, screenTopRight.y);
    }

    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 nextPos = transform.position + new Vector3(dirX * velocity * Time.fixedDeltaTime, 0, 0);

        // Checks if next position is out of bounds
        if (nextPos.x - playerHalfWidth < -screenBounds.x || nextPos.x + playerHalfWidth > screenBounds.x) return;

        transform.position = nextPos;
    }

    private void HandleInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootController.Shoot();
    }

    protected override void Die()
    {
        Debug.Log("Player Died");
        // custom death logic to player
        base.Die();
    }
}

// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣿⣿⣿⣿⣿⣿⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣿⣿⡿⠛⠉⠉⠉⠛⢿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⠋⡀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀
// ⠀⠀⣀⣰⣶⣿⣿⣿⣿⣿⣿⣀⣀⣀⣀⣀⣀⣰⣰⣶⣿⣿⣿⣿⣿⣿⣷⣦⣤⣀
// ⠉⠉⠉⠉⠈⠉⠛⠛⠛⠛⣿⣿⡽⣏⠉⠉⠉⠉⠉⣽⣿⠛⠉⠉⠉⠉⠉⠉⠉⠁
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⣷⣦⣄⣀⣠⣴⣾⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⠿⠿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀-- notluxca