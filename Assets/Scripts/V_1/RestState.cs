using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : IState
{
    private TurnManager turnManager;
    private Character character;
    private CombatAction action;

    public RestState(TurnManager turnManager, Character character, CombatAction action)
    {
        this.turnManager = turnManager;
        this.character = character;
        this.action = action;
    }

    public void Enter()
    {
        character.StartCoroutine(ExecuteRest());
    }

    private IEnumerator ExecuteRest()
    {
        yield return new WaitForSeconds(1.0f);
        turnManager.EndTurn();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
