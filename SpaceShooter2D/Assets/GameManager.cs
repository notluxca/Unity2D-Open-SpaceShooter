using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject boss;
    public EnemySpawner enemySpawner;
    public Animator fadeImage;
    public TextMeshProUGUI wonText;
    public TextMeshProUGUI lostText;
    public int scoreToStartBoss;
    private bool bossSpawned = false;

    private void Awake()
    {
        ScoreManager.ScoreChanged += ScoreChanged;
        PlayerController.PlayerDied += Lose;
        BossController.OnBossDeath += Win;
    }

    private void ScoreChanged(int obj)
    {
        if (boss != null && boss.activeSelf == true) return;
        if (obj >= scoreToStartBoss)
        {
            StartBossFight();
        }
    }

    public void StartBossFight()
    {
        if (bossSpawned) return;
        bossSpawned = true;
        boss.SetActive(true);
        enemySpawner.enemySpawnInterval = 4;
        enemySpawner.obstacleSpawnInterval = 8;
    }

    private void Win()
    {
        StartCoroutine(WinSequence());
    }

    IEnumerator WinSequence()
    {
        fadeImage.Play("FadeIn");
        yield return new WaitForSeconds(1f);
        wonText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

        // show "you won"  text
        // go to menu
    }

    private void Lose()
    {
        StartCoroutine(LoseSequence());
    }

    IEnumerator LoseSequence()
    {
        // fadescreen
        // show "you lose"  text
        // go to menu
        fadeImage.Play("FadeIn");
        yield return new WaitForSeconds(1f);
        lostText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
