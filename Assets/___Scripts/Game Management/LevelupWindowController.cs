using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelupWindowController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private int vitality, wisdom, strength, dexterity, intelligence;

    public TextMeshProUGUI vitalityText, wisdomText, strengthText, dexterityText, intelligenceText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleWindow()
    {
        if (canvasGroup.alpha == 0f)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true; 
            UpdateParameters(); UpdateWindow();
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void UpdateParameters()
    {
        vitality = GameManager.Instance.player.vitality;
        wisdom = GameManager.Instance.player.wisdom;
        strength = GameManager.Instance.player.strength;
        dexterity = GameManager.Instance.player.dexterity;
        intelligence = GameManager.Instance.player.intelligence;
    }

    public void UpdateWindow()
    {
        vitalityText.text = "Vitality: " + vitality;
        wisdomText.text = "Wisdom: " + wisdom;
        strengthText.text = "Strength: " + strength;
        dexterityText.text = "Dexterity: " + dexterity;
        intelligenceText.text = "Intelligence: " + intelligence;
    }

    public void ConfirmPointTransfer()
    {
        GameManager.Instance.player.vitality = vitality;
        GameManager.Instance.player.wisdom = wisdom;
        GameManager.Instance.player.strength = strength;
        GameManager.Instance.player.dexterity = dexterity;
        GameManager.Instance.player.intelligence = intelligence;

        GameManager.Instance.playerHealthComponent.maxHP = GameManager.Instance.CalculateHPFromVitality(vitality);
        GameManager.Instance.player.maxMana = GameManager.Instance.CalculateManaFromWisdom(wisdom);

        UpdateWindow();
    }

    public void AddPoint(int parameter)
    {
        if (GameManager.Instance.player.levelingPoints <= 0)
            return;

        switch (parameter)
        {
            case 0: { vitality++; GameManager.Instance.player.levelingPoints--; break; }
            case 1: { wisdom++; GameManager.Instance.player.levelingPoints--; break; }
            case 2: { strength++; GameManager.Instance.player.levelingPoints--; break; }
            case 3: { dexterity++; GameManager.Instance.player.levelingPoints--; break; }
            case 4: { intelligence++; GameManager.Instance.player.levelingPoints--; break; }
        }

        UpdateWindow();
    }

    public void RemovePoint(int parameter)
    {
        switch (parameter)
        {
            case 0:
                {
                    if (GameManager.Instance.player.vitality == vitality)
                        break;

                    vitality--; GameManager.Instance.player.levelingPoints++; break;
                }
            case 1:
                {
                    if (GameManager.Instance.player.wisdom == wisdom)
                        break;

                    wisdom--; GameManager.Instance.player.levelingPoints++; break;
                }
            case 2:
                {
                    if (GameManager.Instance.player.strength == strength)
                        break;

                    strength--; GameManager.Instance.player.levelingPoints++; break;
                }
            case 3:
                {
                    if (GameManager.Instance.player.dexterity == dexterity)
                        break;

                    dexterity--; GameManager.Instance.player.levelingPoints++; break;
                }
            case 4:
                {
                    if (GameManager.Instance.player.intelligence > intelligence)
                        break;

                    intelligence--; GameManager.Instance.player.levelingPoints++; break;
                }
        }

        UpdateWindow();
    }


}