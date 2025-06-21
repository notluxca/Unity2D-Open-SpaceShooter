using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    public static Action<int> ScoreChanged;

    public void AddScore(int score)
    {
        Score += score;
        ScoreChanged?.Invoke(Score);
    }

    public static void AddScore(int score, ScoreManager scoreManager) => scoreManager.AddScore(score);
}
