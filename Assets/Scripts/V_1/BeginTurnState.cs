using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTurnState : IState
{
    private TurnManager turnManager;

    public BeginTurnState(TurnManager turnManager)
    {
        this.turnManager = turnManager;
    }

    public void Enter()
    {
        Character currentCharacter = turnManager.GetCurrentCharacter();
        if (currentCharacter != null)
        {
            Debug.Log("Begin turn for character: " + currentCharacter.name);
            turnManager.BeginTurnForCharacter(currentCharacter);
        }
        else
        {
            turnManager.BeginNextTurn();
        }
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
