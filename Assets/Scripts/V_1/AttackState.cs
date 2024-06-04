using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private TurnManager turnManager;
    private Character character;
    private CombatAction action;

    public AttackState(TurnManager turnManager, Character character, CombatAction action)
    {
        this.turnManager = turnManager;
        this.character = character;
        this.action = action;
    }

    public void Enter()
    {
        character.StartCoroutine(ExecuteAttack());
    }

    private IEnumerator ExecuteAttack()
    {
        while (Vector3.Distance(character.transform.position, character.Opponent.transform.position) > 0.1f)
        {
            character.transform.position = Vector2.MoveTowards(character.transform.position, character.Opponent.transform.position, 50 * Time.deltaTime);
            yield return null;
        }

        character.Opponent.TakeDamage(action.DamageAmount);
        character.AddEnergy(1); // 增加能量

        while (Vector3.Distance(character.transform.position, character.StartPosition) > 0.1f)
        {
            character.transform.position = Vector2.MoveTowards(character.transform.position, character.StartPosition, 50 * Time.deltaTime);
            yield return null;
        }

        turnManager.EndTurn();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
