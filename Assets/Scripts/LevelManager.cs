using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Transform enemyFinishPoint;

    public int HP;

    public bool isGameEnd;
    private void Awake()
    {
        Instance = this;
    }
    public void OnPlayerGetDamage()
    {
        if(!isGameEnd)
        {
            HP -= Enemy.damage;
            if (HP <= 0)
                isGameEnd = true;
            UIManager.Instance.OnPlayerGetDamage(HP);
        }
    }
    public void GameOver()
    {
        UIManager.Instance.OnGameOver();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
