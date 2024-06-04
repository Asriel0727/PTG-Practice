using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealState : IState
{
    private TurnManager turnManager;
    private Character character;
    private CombatAction action;

    public HealState(TurnManager turnManager, Character character, CombatAction action)
    {
        this.turnManager = turnManager;
        this.character = character;
        this.action = action;
    }

    public void Enter()
    {
        character.StartCoroutine(ExecuteHeal());
    }

    private IEnumerator ExecuteHeal()
    {
        character.Heal(action.HealAmount);
        yield return null;
        turnManager.EndTurn();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
