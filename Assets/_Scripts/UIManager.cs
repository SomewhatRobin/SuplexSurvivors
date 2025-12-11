using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI ScoreboardTMP;
    public TextMeshProUGUI DebugCmbTMP;
    public TextMeshProUGUI DebugCmb1TMP;
    public TextMeshProUGUI DebugCmb2TMP;
    public TextMeshProUGUI hpText;

    [Header("Health")]
    public int maxHealth = 50;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        DebugCmbTMP.text = GameManager.combineValue > 0.00001f ? GameManager.combineValue.ToString("#.000000") : "Nothing";
        DebugCmb1TMP.text = GameManager.combineValue1 > 0.00001f ? GameManager.combineValue1.ToString("#.000000") : "Nothing";
        DebugCmb2TMP.text = GameManager.combineValue2 > 0.00001f ? GameManager.combineValue2.ToString("#.000000") : "Nothing";
    }

    public void TakeDamage(int amount)
    {
        Debug.LogWarning($"Player took {amount} damage!");
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHPUI();

        if (currentHealth <= 0)
            Die();
    }

    void UpdateHPUI()
    {
        hpText.text = $"{currentHealth}/{maxHealth}";
    }

    void Die()
    {
        Debug.Log("Player has died!");
    }
}