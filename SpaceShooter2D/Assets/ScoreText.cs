using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: 0";
        ScoreManager.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int obj)
    {
        scoreText.text = "Score: " + obj;
    }
}
