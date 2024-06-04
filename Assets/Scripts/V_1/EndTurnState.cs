using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnState : IState
{
    private TurnManager turnManager;

    public EndTurnState(TurnManager turnManager)
    {
        this.turnManager = turnManager;
    }

    public void Enter()
    {
        Character currentCharacter = turnManager.GetCurrentCharacter();
        Debug.Log("End turn for character: " + currentCharacter.name);
        turnManager.TriggerEndTurnEvent(currentCharacter);
        turnManager.BeginNextTurn();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
