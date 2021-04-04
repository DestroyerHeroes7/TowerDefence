using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public RaycastHit hit;

    public LayerMask mask;

    public Image healthBar;

    public GameObject gameOverPanel;

    public bool isHold;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (isHold)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask);
        }
    }
    public void OnButtonDown()
    {
        isHold = true;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask);
    }
    public void UpdateHealthBar(float health)
    {
        healthBar.DOKill();
        if (health <= 0)
            healthBar.DOFillAmount(health / 100, 0.5f)
            .OnComplete(() => LevelManager.Instance.GameOver());
        else
            healthBar.DOFillAmount(health / 100, 0.5f);
    }
    public void OnPlayerGetDamage(int health)
    {
        UpdateHealthBar(health);
    }
    public void OnButtonUp()
    {
        isHold = false;
    }
    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void OnRestartButtonClick()
    {
        LevelManager.Instance.RestartGame();
    }
}
