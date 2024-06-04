using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        TurnManager.Instance.OnBeginTurn += OnBeginTurn;
    }

    private void OnDisable()
    {
        TurnManager.Instance.OnBeginTurn -= OnBeginTurn;
    }

    private void OnBeginTurn(Character c)
    {
        if (character == c)
        {
            DetermineCombatAction();
        }
    }

    public void DetermineCombatAction()
    {
        CombatAction action = null;

        if (HasCombatActionOfType(CombatAction.Type.Attack))
        {
            action = GetCombatActionOfType(CombatAction.Type.Attack);
            character.CastCombatAction(action);
        }

        if (action == null)
        {
            Debug.LogError("Error");
            TurnManager.Instance.EndTurn();
        }
    }

    private bool HasCombatActionOfType(CombatAction.Type type)
    {
        return character.CombatActions.Exists(a => a.ActionType == type);
    }

    private CombatAction GetCombatActionOfType(CombatAction.Type type)
    {
        List<CombatAction> availableActions = character.CombatActions.FindAll(a => a.ActionType == type);
        return availableActions[Random.Range(0, availableActions.Count)];
    }
}