using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI ScoreboardTMP;
    public TextMeshProUGUI FinalScoreTMP;
    public TextMeshProUGUI DebugCmbTMP;
    public TextMeshProUGUI DebugCmb1TMP;
    public TextMeshProUGUI DebugCmb2TMP;
    public TextMeshProUGUI hpText;
    public GameObject[] spellPages;
    public GameObject[] manaBar;
    public GameObject gameOverlay;
    public static int bookMark;
    public int reMana;

    [Header("Health")]
    public int maxHealth = 50;
    public int currentHealth;
    public static bool haveHeal;
    public static bool _gameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
        bookMark = 1;
        reMana = 2;
        haveHeal = false;
        _gameOver = false;
        manaBar[0].SetActive(true);
        manaBar[1].SetActive(true);
        spellPages[1].SetActive(false);
        spellPages[2].SetActive(false);
        spellPages[3].SetActive(false);
        spellPages[4].SetActive(false);
        gameOverlay.SetActive(false);
    }

    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        DebugCmbTMP.text = GameManager.combineValue > 0.00001f ? GameManager.combineValue.ToString("#.000000") : "Nothing";
        DebugCmb1TMP.text = GameManager.combineValue1 > 0.00001f ? GameManager.combineValue1.ToString("#.000000") : "Nothing";
        DebugCmb2TMP.text = GameManager.combineValue2 > 0.00001f ? GameManager.combineValue2.ToString("#.000000") : "Nothing";

        if (haveHeal)
        {
            HealHP();
        }

        if (!spellPages[bookMark-1].activeSelf)
        {
            UpdateSpellUI();
        }

        if (GameManager.staMana < reMana)
        {
            DepleteMana();
        }

        else if (GameManager.staMana > reMana)
        {
            FillMana();
        }
    }

    private void FillMana()
    {
        if (GameManager.staMana == 1)
        {
            manaBar[0].SetActive(true);
            manaBar[1].SetActive(false);
        }

        else if (GameManager.staMana == 2)
        {
            manaBar[0].SetActive(true);
            manaBar[1].SetActive(true);
        }

        reMana = GameManager.staMana;
    }

    private void DepleteMana()
    {
        if (GameManager.staMana == 1)
        {
            manaBar[0].SetActive(true);
            manaBar[1].SetActive(false);
        }

        else if (GameManager.staMana == 0)
        {
            manaBar[0].SetActive(false);
            manaBar[1].SetActive(false);
        }

        reMana = GameManager.staMana;
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

    public void HealHP()
    {
        currentHealth += 5;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHPUI();
        haveHeal = false;
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
        _gameOver = true;
        Debug.Log("Player has died!");
        gameOverlay.SetActive(true);
        FinalScoreTMP.text = GameManager.Score.ToString();
    }
}