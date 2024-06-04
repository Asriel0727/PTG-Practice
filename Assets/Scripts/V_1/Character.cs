using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentEnergy;
    [SerializeField] private int maxEnergy;
    [SerializeField] private bool isPlayer;
    [SerializeField] private List<CombatAction> combatActions = new List<CombatAction>();
    [SerializeField] private Character opponent;

    private Vector3 _startPosition;
    private const float movementThreshold = 0.1f;

    public static event UnityAction OnEnergyChange;
    public static event UnityAction OnHealthChange;
    public static event UnityAction<Character> OnDie;

    public int Health { get => currentHealth; }
    public int MaxHealth { get => maxHealth; }
    public float HealthPercentage { get => (float)currentHealth / maxHealth; }
    public int Energy { get => currentEnergy; }
    public int MaxEnergy { get => maxEnergy; }
    public float EnergyPercentage { get => (float)currentEnergy / maxEnergy; }
    public bool IsPlayer { get => isPlayer; }
    public List<CombatAction> CombatActions { get => combatActions; }

    public Character Opponent { get => opponent; }
    public Vector3 StartPosition { get => _startPosition; }

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        OnHealthChange?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChange?.Invoke();
    }

    public void AddEnergy(int amount)
    {
        currentEnergy = Mathf.Min(currentEnergy + amount, maxEnergy);
        OnEnergyChange?.Invoke();
    }

    public void CastCombatAction(CombatAction action)
    {
        IState actionState = null;
        switch (action.ActionType)
        {
            case CombatAction.Type.Attack:
                actionState = new AttackState(TurnManager.Instance, this, action);
                break;
            case CombatAction.Type.Heal:
                actionState = new HealState(TurnManager.Instance, this, action);
                break;
            case CombatAction.Type.Rest:
                actionState = new RestState(TurnManager.Instance, this, action);
                break;
            default:
                Debug.Log("Error action");
                return;
        }

        TurnManager.Instance.ChangeState(actionState);
    }
}