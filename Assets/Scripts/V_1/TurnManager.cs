using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private Character[] characters;
    [SerializeField] private float nextTurnDelay = 1.5f;

    private int currentCharacterIndex = -1;
    private Character currentCharacter;

    public event UnityAction<Character> OnBeginTurn;
    public event UnityAction<Character> OnEndTurn;

    public static TurnManager Instance;

    private IState currentState;

    public Character GetCurrentCharacter() { return currentCharacter; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        Character.OnDie += OnCharacterDie;
    }

    private void OnDisable()
    {
        Character.OnDie -= OnCharacterDie;
    }

    private void Start()
    {
        BeginNextTurn();
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void BeginNextTurn()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        currentCharacter = characters[currentCharacterIndex];

        ChangeState(new BeginTurnState(this));
    }

    public void EndTurn()
    {
        ChangeState(new EndTurnState(this));
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private IEnumerator ChangeStateWithDelay(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        yield return new WaitForSeconds(nextTurnDelay);

        currentState = newState;
        currentState.Enter();
    }

    public void TriggerEndTurnEvent(Character character)
    {
        OnEndTurn?.Invoke(character);
    }

    private void OnCharacterDie(Character character)
    {
        if (character.IsPlayer)
        {
            Debug.Log("Game Over");
        }
        else
        {
            Debug.Log("Victory");
        }
    }

    public void BeginTurnForCharacter(Character character)
    {
        OnBeginTurn?.Invoke(character);
    }
}
