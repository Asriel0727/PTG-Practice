using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : IState
{
    private TurnManager turnManager;

    public EnemyTurnState(TurnManager turnManager)
    {
        this.turnManager = turnManager;
    }

    public void Enter()
    {
        Debug.Log("Enemy's turn.");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
