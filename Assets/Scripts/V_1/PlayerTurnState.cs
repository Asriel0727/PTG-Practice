using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : IState
{
    private TurnManager turnManager;

    public PlayerTurnState(TurnManager turnManager)
    {
        this.turnManager = turnManager;
    }

    public void Enter()
    {
        Debug.Log("Player's turn.");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
