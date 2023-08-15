using UnityEngine;

public class ClassManager : MonoBehaviour
{
    public void ApplyClassParameters(PlayerClass playerClass)
    {
        GameManager.Instance.player.strength = playerClass.strength;
        GameManager.Instance.player.dexterity = playerClass.dexterity;
        GameManager.Instance.player.vitality = playerClass.vitality;
        GameManager.Instance.player.intelligence = playerClass.intelligence;
        GameManager.Instance.player.wisdom = playerClass.wisdom;

        GameManager.Instance.playerHealthComponent.maxHP = GameManager.Instance.CalculateHPFromVitality(playerClass.vitality);
        GameManager.Instance.player.maxMana = GameManager.Instance.CalculateManaFromWisdom(playerClass.wisdom);

        GameManager.Instance.playerAnimator.runtimeAnimatorController = playerClass.animatorController;
    }
}