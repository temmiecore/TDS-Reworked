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

        ///Change player's HP and Mana proportionate to Vitality and Wisdom

        GameManager.Instance.playerAnimator.runtimeAnimatorController = playerClass.animatorController;
    }
}