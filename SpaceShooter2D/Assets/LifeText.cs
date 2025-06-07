using TMPro;
using UnityEngine;

public class LifeText : MonoBehaviour
{
    PlayerController playerController;
    TextMeshProUGUI lifeText;

    private void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        lifeText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        lifeText.text = "Life: " + playerController.CurrentHealth;
    }

    private void Update()
    {
        lifeText.text = "Life: " + playerController.CurrentHealth;
    }
}
