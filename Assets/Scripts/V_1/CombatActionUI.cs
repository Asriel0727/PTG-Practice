using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatActionUI : MonoBehaviour
{
    [SerializeField] private GameObject visualContainer;
    [SerializeField] private Button[] combatActionButtons;

    private void OnEnable()
    {
        TurnManager.Instance.OnBeginTurn += OnBeginTurn;
        TurnManager.Instance.OnEndTurn += OnEndTurn;
    }

    private void OnDisable()
    {
        TurnManager.Instance.OnBeginTurn -= OnBeginTurn;
        TurnManager.Instance.OnEndTurn -= OnEndTurn;
    }

    void OnBeginTurn(Character character)
    {
        if (!character.IsPlayer)
        {
            return;
        }

        for (int i = 0; i < combatActionButtons.Length; i++)
        {
            if (i < character.CombatActions.Count)
            {
                CombatAction combatAction = character.CombatActions[i];
                combatActionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = combatAction.DisplayName;
                combatActionButtons[i].onClick.RemoveAllListeners();
                combatActionButtons[i].onClick.AddListener(() => { OnClickCombatAction(combatAction); });
                combatActionButtons[i].gameObject.SetActive(true);
            }
            else
            {
                combatActionButtons[i].gameObject.SetActive(false);
            }
        }

        visualContainer.SetActive(true);
    }

    void OnEndTurn(Character character)
    {
        visualContainer.SetActive(false);

        foreach (var button in combatActionButtons)
        {
            button.interactable = true;
        }
    }

    void OnClickCombatAction(CombatAction combatAction)
    {
        foreach (var b in combatActionButtons)
        {
            b.interactable = false;
        }

        TurnManager.Instance.GetCurrentCharacter().CastCombatAction(combatAction);
    }
}
