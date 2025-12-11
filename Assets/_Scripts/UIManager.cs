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
    public GameObject[] spellPages;
    public static int bookMark;

    [Header("Health")]
    public int maxHealth = 50;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
        bookMark = 1;
        spellPages[1].SetActive(false);
        spellPages[2].SetActive(false);
        spellPages[3].SetActive(false);
        spellPages[4].SetActive(false);
    }

    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        DebugCmbTMP.text = GameManager.combineValue > 0.00001f ? GameManager.combineValue.ToString("#.000000") : "Nothing";
        DebugCmb1TMP.text = GameManager.combineValue1 > 0.00001f ? GameManager.combineValue1.ToString("#.000000") : "Nothing";
        DebugCmb2TMP.text = GameManager.combineValue2 > 0.00001f ? GameManager.combineValue2.ToString("#.000000") : "Nothing";

        if (!spellPages[bookMark-1].activeSelf)
        {
            UpdateSpellUI();
        }
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

    void UpdateSpellUI()
    {
        for (int i = 0; i < 5;  i++)
        {
            if(i+1 == bookMark)
            spellPages[i].SetActive(true);

            else
            spellPages[i].SetActive(false);

        }
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